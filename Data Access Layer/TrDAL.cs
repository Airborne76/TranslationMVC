using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TranslationMVC.Models;

namespace TranslationMVC.Data_Access_Layer
{
    public class TrDAL :DbContext
    {
        public DbSet<userinfo> users { get; set; }
        public DbSet<textinfo> texts { get; set; }
        public DbSet<translationinfo> translations { get; set; }
        public DbSet<projectinfo> projects { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<userinfo>().ToTable("TBuser");
            modelBuilder.Entity<textinfo>().ToTable("TBtext");
            modelBuilder.Entity<translationinfo>().ToTable("TBtranslation");
            modelBuilder.Entity<projectinfo>().ToTable("TBproject");
            base.OnModelCreating(modelBuilder);
        }

    }
}