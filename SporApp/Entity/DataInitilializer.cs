using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SporApp.Entity
{
    public class DataInitilializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var programs = new List<Program>()
            {
                new Program(){Id=1,Name="agirlik" },
                new Program(){Id=2,Name="kosu"}

            };

            foreach (var program in programs)
            {
                context.Programs.Add(program);
            }
            context.SaveChanges();

            var users = new List<User>
            {
                new User(){ Id=1, Name="gizem", Surname="yavuz"},
                new User(){ Id=2, Name="ibrahim", Surname="aker"}
            };

            foreach(var user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();





            base.Seed(context);
        }


    }
}