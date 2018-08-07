using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domowe.Model
{
    [Table("Grade")]
    public class Grade
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        public int StudentId { get; set; }
        [Required]
        [ForeignKey("TeacherId")]
        public virtual Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        [Required]
        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }
        public int SubjectId { get; set; }
        [Required]
        public int Value { get; set; }

    }
}
