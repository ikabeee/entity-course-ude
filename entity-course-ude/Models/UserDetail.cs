using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace entity_course_ude.Models
{
    public class UserDetail
    {
        [Key]
        public int UserDetail_Id { get; set; }
        [Required]
        public string Code { get; set; }
        public string Sport { get; set; }
        public string Pet { get; set; }
        public User User { get; set; }
    }
}