using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SporApp.Entity
{
    public class DataContext:DbContext
    {
        public DataContext() : base("dataConnection")
        {
            Database.SetInitializer(new DataInitilializer());
        }

        public DbSet<Program> Programs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProgram> UserPrograms { get; set; }
    }
}