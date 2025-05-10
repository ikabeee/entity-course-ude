using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace entity_course_ude.Models
{
    public class Category
    {
        // [Key]
        public int Category_Id { get; set; }
        // [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "[NULL]")]
        // [Required]
        public string Name { get; set; }
        // [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }
        // [Required]
        public List<Product> Product { get; set; }
        public ICollection<ProductTag> ProductTag { get; set; }

        public bool Active { get; set; }

    }
}