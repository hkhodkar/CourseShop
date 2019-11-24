using CourseShop.DataLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;

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

            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        UserId = 1,
                        ActivateCode = "f53c00d5676e451ea31e52f4410d23c3",
                        Email = "hatef.khodkar@hotmail.com",
                        IsActive = true,
                        IsDeleted = false,
                        UserAvatar = "default.jpg",
                        PasswordHash = "20-2C-B9-62-AC-59-07-5B-96-4B-07-15-2D-23-4B-70",
                        RegisterDate = DateTime.Now,
                        Username = "هاتف خودکار",
                    }
                );

            modelBuilder.Entity<UserRole>()
                .HasData(
                new UserRole
                {
                    USR_RoleId = 1,
                    UserId = 1,
                    RoleId = 1
                });

            modelBuilder.Entity<RolePermission>()
                .HasData(
                new RolePermission
                {
                    RP_Id = 1,
                    RoleId = 1,
                    PermissionId = 1
                },
                new RolePermission
                {
                    RP_Id = 2,
                    RoleId = 1,
                    PermissionId = 2
                },
                new RolePermission
                {
                    RP_Id = 3,
                    RoleId = 1,
                    PermissionId = 3
                },
                new RolePermission
                {
                    RP_Id = 4,
                    RoleId = 1,
                    PermissionId = 4
                },
                new RolePermission
                {
                    RP_Id = 5,
                    RoleId = 1,
                    PermissionId = 5
                },
                new RolePermission
                {
                    RP_Id = 6,
                    RoleId = 1,
                    PermissionId = 6
                },
                new RolePermission
                {
                    RP_Id = 7,
                    RoleId = 1,
                    PermissionId = 7
                },
                new RolePermission
                {
                    RP_Id = 8,
                    RoleId = 1,
                    PermissionId = 8
                },
                new RolePermission
                {
                    RP_Id = 9,
                    RoleId = 1,
                    PermissionId = 9
                }
                );
        }

        #endregion

    }
    #endregion

}
