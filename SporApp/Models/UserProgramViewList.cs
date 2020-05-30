using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SporApp.Models
{
    public class UserProgramViewList
    {
        public int Id { get; set; }

        public int ProgramId { get; set; }

        public string ProgramName { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime ScheduleTime { get; set; }

        public int Duration { get; set; }

        public string Description { get; set; }

        public int Calories { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}