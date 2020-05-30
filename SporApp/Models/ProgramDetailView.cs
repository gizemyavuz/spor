﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SporApp.Models
{
    public class ProgramDetailView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Calories { get; set; }

        public string ImageUrl { get; set; }

        public string Link { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}