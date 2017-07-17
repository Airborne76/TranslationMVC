using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using TranslationMVC.Business_Layer;
using TranslationMVC.Models;
using TranslationMVC.ViewModel;

namespace TranslationMVC.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult projectlist()
        {
            ProjectBusinessLayer pbl = new ProjectBusinessLayer();
            ProjectListViewModel plvm = new ProjectListViewModel();
            List<projectinfo> projectlist=pbl.GetProjectInfo();
            plvm.projectlist = projectlist;
            return View(plvm);
        }
        [Authorize]
        public ActionResult projectdetail(int id)
        {
                ProjectDetailViewModel pdvm = new ProjectDetailViewModel();
                pdvm.projectinfo = ProjectBusinessLayer.getprojectbyid(id);            
                return View(pdvm);      
        }
        [HttpPost]
        public ActionResult upload(int id,string Translation)
        {
            string username = Authentication.getUserName();
            translationinfo ti = TranslationBusinessLayer.Upload(id, Translation, username);
            TranslatedViewModel tvm = new TranslatedViewModel()
            {
                username = ti.userinfo.username,
                translatedText = ti.translatedText,
                updateTime = ti.updateTime
            };
            return Json(tvm, JsonRequestBehavior.AllowGet);
          
        }


    }
}