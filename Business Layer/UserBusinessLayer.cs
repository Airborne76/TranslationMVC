using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using TranslationMVC.Data_Access_Layer;
using TranslationMVC.Models;

namespace TranslationMVC.Business_Layer
{
    public class UserBusinessLayer
    {
        public List<userinfo> GetUserInfo()
        {

                TrDAL td = new TrDAL();
                return td.users.ToList();
        }
        public Task<bool> Add(userinfo user)
        {
            return Task.Run(() =>
            {
                TrDAL td = new TrDAL();
                int i = td.users.Where(u => u.username == user.username).Count();
                if (i == 0)
                {
                    td.users.Add(user);
                    td.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            );
        }
        public static userinfo getUser(string username)
        {
            TrDAL td = new TrDAL();
            userinfo user = td.users.Where(u => u.username == username).FirstOrDefault();
            return user;
        }
        public Task<string> loginAsync(userinfo user)
        {
            return Task.Run(() =>
            {
                TrDAL td = new TrDAL();
                var userlist = td.users.Where(u => u.username == user.username && u.password == user.password);
                if (userlist.Count() > 0)
                {
                    if (userlist.First().rights == "admin")
                    {
                        return "admin";
                    }
                    else
                    {
                        return "user";
                    }

                }
                else
                {
                    return "NoUser";
                }
            });

        }
        public static string GetMD5(string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytValue, bytHash;
            bytValue = System.Text.Encoding.UTF8.GetBytes(text);
            bytHash = md5.ComputeHash(bytValue);
            md5.Clear();
            string sTemp = "";
            for (int i = 0; i < bytHash.Length; i++)
            {
                sTemp += bytHash[i].ToString("X").PadLeft(2, '0');
            }
            return sTemp.ToLower();
        }
    }
}