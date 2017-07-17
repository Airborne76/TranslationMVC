using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace TranslationMVC.Business_Layer
{
    public class Authentication
    {
        public static string SetCookie(string UserName, string PassWord)
        {
                string UserData = UserName + "#" + PassWord;
                if (true)
                {
                    //数据放入ticket
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, UserName, DateTime.Now, DateTime.Now.AddMinutes(60), false, UserData);
                    //数据加密
                    string enyTicket = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, enyTicket);
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
                return getUserName();
        }
        //是否登录
        public static bool isLogin()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }
        //注销登录
        public static void logOut()
        {
            FormsAuthentication.SignOut();
        }
        //获取用户名
        public static string getUserName()
        {
            if (isLogin())
            {
                string strUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
                string[] UserData = strUserData.Split('#');
                if (UserData.Length != 0)
                {
                    return UserData[0].ToString();
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
    }
}