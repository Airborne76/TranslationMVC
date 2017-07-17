using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TranslationMVC.Data_Access_Layer;
using TranslationMVC.Models;
using TranslationMVC.ViewModel;

namespace TranslationMVC.Business_Layer
{
    public class ProjectBusinessLayer
    {
        public List<projectinfo> GetProjectInfo()
        {
            TrDAL td = new TrDAL();
            return td.projects.ToList();
        }
        public Task<bool> UploadAsync(HomeViewModel hvm)
        {
            return Task.Run(() =>
            {
                return Upload(hvm);
            }
            );
        }
        public static projectinfo getproject(string projectname)
        {
            TrDAL td = new TrDAL();
            projectinfo project = td.projects.Where(p => p.projectname == projectname).FirstOrDefault();
            return project;
        }
        public static projectinfo getprojectbyid(int id)
        {
            TrDAL td = new TrDAL();
            projectinfo project = td.projects.Where(p => p.Id == id).FirstOrDefault();
            return project;
        }
        public bool Upload(HomeViewModel hvm)
        {
            TrDAL td = new TrDAL();
            projectinfo project = new projectinfo()
            {
                projectname = hvm.projectname,
                user = td.users.Where(u => u.username == hvm.username).FirstOrDefault(),
                message = hvm.message,
                createtime = DateTime.Now
            };           
            int i = td.projects.Where(p => p.projectname == project.projectname).Count();         
            if (i == 0)
            {                
                td.projects.Add(project);
                td.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }          
        }
    }
}