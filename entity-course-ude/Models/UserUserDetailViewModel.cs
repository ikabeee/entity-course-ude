using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace entity_course_ude.Models
{
    public class UserUserDetailViewModel
    {
        public User User { get; set; }
        public IEnumerable<SelectListItem> UserDetailList;
    }
}