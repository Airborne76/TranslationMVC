using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TranslationMVC.Models
{
    public class userinfo
    {
        [Key]
        public int ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string rights { get; set; }
        public virtual ICollection<textinfo> projects { get; set; }
    }
}