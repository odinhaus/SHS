using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using SHS.Models;

namespace SHS.Data
{
    public static class DataContext
    {
        public static FeedbackCtx FeedbackContext()
        {
            return new FeedbackCtx();
        }

        public class FeedbackCtx : DbContext
        {
            public FeedbackCtx() : base("DefaultConnection")
            { }

            public DbSet<Feedback> Feedback { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
        }
    }
}