using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SporApp.Entity
{
    public class Program
    {
        public Program()
        {
            CreationTime = DateTime.Now;
            UpdateTime = DateTime.Now;
           // UserProgram = new List<UserProgram>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Calories { get; set; }

        public string ImageUrl { get; set; }

        public string Link { get; set; }

        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public ICollection<UserProgram> UserProgram { get; set; }
    }
}