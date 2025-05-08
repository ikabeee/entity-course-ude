using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace entity_course_ude.Models
{
    public class User
    {
        public int Id {get; set;}
        public string Name {get; set;} 
        // [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string Email {get; set;}

        [ForeignKey("UserDetail")]
        public int UserDetail_Id { get; set; }
        public required UserDetail UserDetail {get; set;}
    }
}