using CourseShop.DataLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace CourseShop.DataLayer.Context
{
    public class CourseShopContext : DbContext
    {
        public CourseShopContext(DbContextOptions<CourseShopContext> options) : base(options)
        {

        }

        #region User

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        #endregion
    }
}
