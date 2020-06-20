using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SporApp.Entity
{
    public class DataContext:DbContext
    {
        public DataContext() : base(ConfigurationManager.AppSettings["Platform"].ToString() == "1" ? "dataConnection_dev" : "dataConnection_prod")
        {
            Database.SetInitializer(new DataInitilializer());
        }

        public DbSet<Program> Programs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProgram> UserPrograms { get; set; }
    }
}