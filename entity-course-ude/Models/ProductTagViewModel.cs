using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace entity_course_ude.Models
{
    public class ProductTagViewModel
    {
        public ProductTag ProductTag { get; set; }
        public Product Product { get; set; }
        public IEnumerable<ProductTag> ProductTagList { get; set; }
        public IEnumerable<SelectListItem> TagList { get; set; }
    }
}