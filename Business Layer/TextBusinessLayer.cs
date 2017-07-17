using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using TranslationMVC.Data_Access_Layer;
using TranslationMVC.Models;
using TranslationMVC.ViewModel;

namespace TranslationMVC.Business_Layer
{
    public class TextBusinessLayer
    {
        public List<textinfo> GetTextInfo()
        {
            TrDAL td = new TrDAL();
            return td.texts.ToList();
        }
        public bool Upload(List<textinfo> textinfo,string projectname)
        {
            TrDAL td = new TrDAL();
            projectinfo project = td.projects.Where(p => p.projectname == projectname).FirstOrDefault();           
            textinfo.ForEach(text =>
            {
                text.project = project;
                td.texts.Add(text);
            });
            td.SaveChanges();
            return true;
        }
        public static List<textinfo> GetText(HomeViewModel hvm)
        {
            StreamReader csvreader = new StreamReader(hvm.fileUpload.InputStream);
            JavaScriptSerializer Serializer = new JavaScriptSerializer();
            List<filetext> filetext = Serializer.Deserialize<List<filetext>>(csvreader.ReadToEnd());
            List<textinfo> textinfo = new List<textinfo>();            
            foreach(var ft in filetext)
            {
                textinfo ti = new textinfo()
                {
                    key=ft.key,
                    text=ft.text
                };
                textinfo.Add(ti);
            }
            return textinfo;
        }
    }
}