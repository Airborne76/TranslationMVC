using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TranslationMVC.ViewModel
{
    public class UserViewModel
    {
        [Required(ErrorMessage ="请输入用户名")]
        [StringLength(maximumLength:10,MinimumLength =2, ErrorMessage ="用户名长度2个到10个字符")]        
        public string username { get; set; }
        [Required(ErrorMessage ="请输入密码")]
        [StringLength(maximumLength:16,MinimumLength =6,ErrorMessage ="密码长度6到16个字符")]
        public string password { get; set; }
    }
}