using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace entity_course_ude.Models
{
    public class Tag
    {
        // [Key]
        public int Tag_Id { get; set; }
        // [Required]
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}