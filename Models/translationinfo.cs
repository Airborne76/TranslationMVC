using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TranslationMVC.Models
{
    public class translationinfo
    {
        [Key]
        public int Id { get; set; }
        public virtual userinfo userinfo { get; set; }
        public virtual textinfo textinfo { get; set; }
        public string translatedText { get; set; }
        public DateTime? updateTime { get; set; }
    }
}