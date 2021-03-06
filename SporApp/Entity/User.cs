﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SporApp.Entity
{
    public class User
    {
        public User()
        {
            CreationTime = DateTime.Now;
            UpdateTime = DateTime.Now;
           // UserProgram = new List<UserProgram>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public bool IsAdmin { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int Weight { get; set; }
        public DateTime CreationTime { get; set; }

        public DateTime UpdateTime { get; set; }
        public ICollection<UserProgram> UserProgram { get; set; }
    }
}