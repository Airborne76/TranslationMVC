using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TranslationMVC.Models
{
    public class textinfo
    {
        [Key]
        public int Id { get; set; }
        public string key { get; set; }
        public string text { get; set; }
        public projectinfo project { get; set; }
    }
}