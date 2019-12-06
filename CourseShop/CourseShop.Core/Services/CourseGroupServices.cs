using CourseShop.Core.Interfaces;
using CourseShop.DataLayer.Context;
using CourseShop.DataLayer.Entity.Courses;
using System.Collections.Generic;
using System.Linq;

namespace CourseShop.Core.Services
{
    public class CourseGroupServices : ICourseGroupServices
    {
        private readonly CourseShopContext _context;


        public CourseGroupServices(CourseShopContext context)
        {
            _context = context;
        }

        public IList<CourseGroup> GetCourseGroupList()
        {
            return _context.CourseGroup.ToList();
        }
    }
}
