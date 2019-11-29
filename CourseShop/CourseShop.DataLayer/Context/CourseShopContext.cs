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

        #region permissions

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<RolePermission> RolePermissions { get; set; }

        #endregion

        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(u => u.IsDeleted == false);

            modelBuilder.Entity<Role>().HasQueryFilter(r => r.IsDeleted == false);

            #region Seeding Database

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


            modelBuilder.Entity<Permission>()
                .HasData(

                    new Permission()
                    {
                        PermissionId = 1,
                        PermissionTitle = "پنل مدیریت",
                        PermissionNameForAttribute = "admin panel",
                        ParrentId = null
                    },
                    new Permission()
                    {
                        PermissionId = 2,
                        PermissionTitle = "مدیریت کاربران",
                        PermissionNameForAttribute = "user management",
                        ParrentId = 1
                    },
                    new Permission()
                    {
                        PermissionId = 3,
                        PermissionTitle = "اضافه کردن کاربر",
                        PermissionNameForAttribute = "add user",
                        ParrentId = 2
                    },
                    new Permission()
                    {
                        PermissionId = 4,
                        PermissionTitle = "ویرایش  کاربر",
                        PermissionNameForAttribute = "edit user",
                        ParrentId = 2
                    },
                    new Permission()
                    {
                        PermissionId = 5,
                        PermissionTitle = "حذف  کاربر",
                        PermissionNameForAttribute = "delete user",
                        ParrentId = 2
                    },

                    new Permission()
                    {
                        PermissionId = 6,
                        PermissionTitle = "مدیریت نقش ها",
                        PermissionNameForAttribute = "role management",
                        ParrentId = 1
                    },
                    new Permission()
                    {
                        PermissionId = 7,
                        PermissionTitle = "اضافه کردن نقش",
                        PermissionNameForAttribute = "add user",
                        ParrentId = 6
                    },
                    new Permission()
                    {
                        PermissionId = 8,
                        PermissionTitle = "ویرایش  نقش",
                        PermissionNameForAttribute = "edit user",
                        ParrentId = 6
                    },
                    new Permission()
                    {
                        PermissionId = 9,
                        PermissionTitle = "حذف  نقش",
                        PermissionNameForAttribute = "delete user",
                        ParrentId = 6
                    }

                );
        }

        #endregion

    }
    #endregion

}
