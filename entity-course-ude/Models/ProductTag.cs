using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace entity_course_ude.Models
{
    public class ProductTag
    {
        // [ForeignKey("Tag")]
        public int Tag_Id { get; set; }
        // [ForeignKey("Product")]
        public int Product_Id { get; set; }

        public Product Product { get; set; }
        public Tag Tag { get; set; }
    }
}