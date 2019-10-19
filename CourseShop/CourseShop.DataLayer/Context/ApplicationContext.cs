using Microsoft.EntityFrameworkCore;

namespace CourseShop.DataLayer.Context
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }


    }
}
