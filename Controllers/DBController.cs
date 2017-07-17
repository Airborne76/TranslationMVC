using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranslationMVC.Models;
using TranslationMVC.ViewModel;
using TranslationMVC.Business_Layer;
using System.Threading.Tasks;

namespace TranslationMVC.Controllers
{
    public class DBController : Controller
    {
        // GET: DB
        [Authorize]
        public ActionResult Index()
        {
            UserBusinessLayer ubl = new UserBusinessLayer();
            UserListViewModel ulViewModel = new UserListViewModel();
            List<userinfo> userlist =ubl.GetUserInfo();
            ulViewModel.userlist = userlist;
            return View(ulViewModel);
        }

    }
}