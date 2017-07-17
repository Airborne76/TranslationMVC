using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TranslationMVC.Data_Access_Layer;
using TranslationMVC.Models;

namespace TranslationMVC.Business_Layer
{
    public class TranslationBusinessLayer
    {
        public List<translationinfo> GetTranslationInfo()
        {
            TrDAL td = new TrDAL();
            return td.translations.ToList();
        }
        public static translationinfo Upload(int id, string Text, string username)
        {
            TrDAL td = new TrDAL();
            textinfo ti = td.texts.Where(t => t.Id == id).FirstOrDefault();

            if (td.translations.Where(t => t.textinfo.Id == ti.Id).Count() > 0)
            {
                translationinfo oldtranslation = td.translations.Where(t => t.textinfo.Id == ti.Id).FirstOrDefault();
                oldtranslation.userinfo = td.users.Where(u => u.username == username).FirstOrDefault();
                oldtranslation.textinfo = ti;
                oldtranslation.translatedText = Text;
                oldtranslation.updateTime = DateTime.Now;
                td.SaveChanges();
                return oldtranslation;
            }
            else
            {
                translationinfo translation = new translationinfo()
                {
                    userinfo = td.users.Where(u => u.username == username).FirstOrDefault(),
                    textinfo = ti,
                    translatedText = Text,
                    updateTime = DateTime.Now
                };
                td.translations.Add(translation);
                td.SaveChanges();
                return translation;
            }
        }
    }
}