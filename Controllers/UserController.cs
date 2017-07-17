using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranslationMVC.ViewModel;
using TranslationMVC.Models;
using TranslationMVC.Business_Layer;
using System.Threading.Tasks;

namespace TranslationMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddUser(UserViewModel uvm)
        {
            if (ModelState.IsValid)
            {
                userinfo user = new userinfo();
                user.username = uvm.username;
                user.password = UserBusinessLayer.GetMD5(uvm.password);
                user.rights = "user";
                UserBusinessLayer ubl = new UserBusinessLayer();
                if (await ubl.Add(user))
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.errorMsg = "用户名已存在";
                    return View("Register");
                }
            }
            else
            {
                return View("Register",uvm);
            }

        }
        public ActionResult Login()
        {
            if (Authentication.isLogin())
            {
               return RedirectToAction("Home");
            }
            else
            {
                return View();
            }            
        }
        [HttpPost]
        public async Task<ActionResult> DoLogin(UserViewModel uvm)
        {
            if (ModelState.IsValid)
            {
                userinfo user = new userinfo();
                user.username = uvm.username;
                user.password = UserBusinessLayer.GetMD5(uvm.password);
                UserBusinessLayer ubl = new UserBusinessLayer();
                switch (await ubl.loginAsync(user))
                {
                    case "admin":
                        return RedirectToAction("Index", "DB");
                    case "user":
                        SignInAsync(user);
                        return RedirectToAction("Index", "Home");
                    case "NoUser":
                        ViewBag.errorMsg = "用户名不存在或密码错误";
                        return View("Login",uvm);
                }
                return new EmptyResult();
            }
            else
            {
                return View("Login",uvm);
            }
        }
        [Authorize]
        public ActionResult Home()
        {
            HomeViewModel hvm = new HomeViewModel();
            hvm.username = Authentication.getUserName();
            return View(hvm);
        }
        [HttpPost]
        public ActionResult Upload(HomeViewModel hvm)
        {
            hvm.username = Authentication.getUserName();
            //projectinfo project = new projectinfo()
            //{
            //    projectname = hvm.projectname,
            //    user = UserBusinessLayer.getUser(hvm.username),
            //    message = hvm.message,
            //    createtime = DateTime.Now
            //};
            ProjectBusinessLayer pbl = new ProjectBusinessLayer();
            TextBusinessLayer tbl = new TextBusinessLayer();
            if(pbl.Upload(hvm))
            {
                List<textinfo> textinfo = TextBusinessLayer.GetText(hvm);
                tbl.Upload(textinfo,hvm.projectname);
                ViewBag.uploadmsg = "上传成功";
                return RedirectToAction("Home");
            }
            else
            {
                ViewBag.uploadmsg = "项目名已存在";
                return RedirectToAction("Home");
            }                
        }
        private void SignInAsync(userinfo user)
        {
            Authentication.logOut();
            Authentication.SetCookie(user.username, user.password);
        }
        public ActionResult Logout()
        {
            Authentication.logOut();
            return RedirectToAction("Login");
        }
        
    }
}