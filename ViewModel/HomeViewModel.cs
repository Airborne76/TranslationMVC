using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TranslationMVC.ViewModel
{
    public class HomeViewModel
    {
        public HttpPostedFileBase fileUpload { get; set; }       
        public string username { get; set; }
        [Required(ErrorMessage = "请输入用户名")]
        public string projectname { get; set; }
        public string message { get; set; }
    }
}