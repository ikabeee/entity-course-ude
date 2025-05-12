using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entity_course_ude.Models
{
    public class CategoryFromView
    {
        public int Category_Id { get; set; }
        public string Title { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}