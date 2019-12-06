﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseShop.DataLayer.Entity.Courses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseShop.Web.Pages.Admin.Courses
{
    public class CreateCourseModel : PageModel
    {
        [BindProperty]
        public Course Course { get; set; }

        public void OnGet()
        {

        }
    }
}