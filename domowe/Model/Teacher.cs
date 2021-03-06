﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domowe.Model
{
    [Table("Teacher")]
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        
        [ForeignKey("SubjectId")]
        
        public virtual Subject Subject { get; set; }
        public int SubjectId { get; set; }
    }
}
