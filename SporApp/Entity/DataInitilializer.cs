using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SporApp.Entity
{
    public class DataInitilializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var programs = new List<Program>()
            {
                new Program(){Id=1,Name="agirlik", Description ="dfds" },
                new Program(){Id=2,Name="kosu", Description ="dfsd"}

            };

            foreach (var program in programs)
            {
                context.Programs.Add(program);
            }
            context.SaveChanges();

            var users = new List<User>
            {
                new User(){ Id=1, Name="gizem", Surname="yavuz",Email="gizem",Phone="05303381196",Password="123456",IsAdmin=true,Age=24,Gender="F",Weight=5},
                new User(){ Id=2, Name="ibrahim", Surname="aker",Email="ibrahim",Phone="05303381196",Password="123456",IsAdmin=true,Age=24,Gender="M",Weight=5},
                new User(){ Id=3, Name="gizem", Surname="yavuz",Email="gizem.admin",Phone="05303381196",Password="1",IsAdmin=true,Age=24,Gender="F",Weight=5},
                new User(){ Id=4, Name="gizem", Surname="yavuz",Email="gizem.user",Phone="05303381196",Password="1",IsAdmin=false,Age=24,Gender="F",Weight=5 }
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