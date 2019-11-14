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

        #region Wallet

        public DbSet<Wallet> Wallets { get; set; }

        public DbSet<WalletType> WalletTypes { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(u => u.IsDeleted == false );

            modelBuilder.Entity<WalletType>()
                .HasData(
                    new WalletType
                    {
                        TypeId = 1,
                        TypeTitle = "واریز",
                    },
                    new WalletType
                    {
                        TypeId = 2,
                        TypeTitle = "برداشت"
                    }
                );

            modelBuilder.Entity<Role>()
                .HasData(
                new Role
                {
                    RoleId = 1,
                    RoleTitle = "مدیر سایت"
                },
                 new Role
                 {
                     RoleId = 2,
                     RoleTitle = "استاد"
                 });
        }
    }
}
