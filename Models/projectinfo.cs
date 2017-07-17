using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TranslationMVC.Models
{
    public class projectinfo
    {
        [Key]
        public int Id { get; set; }
        public string projectname { get; set; }
        public virtual userinfo user { get; set; }
        public DateTime? createtime { get; set; }
        public string message { get; set; }
        public virtual ICollection<textinfo> texts { get; set; }
    }
}