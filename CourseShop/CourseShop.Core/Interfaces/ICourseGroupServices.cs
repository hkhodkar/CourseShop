using CourseShop.DataLayer.Entity.Courses;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseShop.Core.Interfaces
{
   public interface ICourseGroupServices
    {
        IList<CourseGroup> GetCourseGroupList();
    }
}
