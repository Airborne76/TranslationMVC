using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TranslationMVC.ViewModel
{
    public class TranslatedViewModel
    {
        public string username { get; set; }
        public string translatedText { get; set; }
        public DateTime? updateTime { get; set; }
    }
}