using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SporApp.Entity
{
    public class UserProgram
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Program")]
        public int ProgramId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public DateTime ScheduleTime { get; set; }
        public int Duration { get; set; }

        public string Description { get; set; }

        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public virtual User User { get; set; }

        public virtual Program Program { get; set; }

    }
}