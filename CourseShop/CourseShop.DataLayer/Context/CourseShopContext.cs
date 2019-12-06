using CourseShop.DataLayer.Entity;
using CourseShop.DataLayer.Entity.Courses;
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

        #region Course

        public DbSet<CourseGroup> CourseGroup { get; set; }

        public DbSet<CourseLevel> CourseLevel { get; set; }

        public DbSet<CourseStatus> CourseStatus { get; set; }

        public DbSet<Course> Course { get; set; }

        public DbSet<CourseEpisode> CourseEpisode { get; set; }


        #endregion

        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(u => u.IsDeleted == false);

            modelBuilder.Entity<Role>().HasQueryFilter(r => r.IsDeleted == false);

            modelBuilder.Entity<CourseGroup>().HasQueryFilter(c => c.IsDeleted == false);

            #region Seeding Database

            #region SeedWalletType
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
            #endregion

            #region seedPermission
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

            #endregion

            #region SeedCourseGroup
            modelBuilder.Entity<CourseGroup>().HasData(

             new CourseGroup
             {
                 CourseGroupId = 1,
                 CourseGroupTitle = "برنامه نویسی موبایل",
                 IsDeleted = false,
                 ParentId = null
             },

             new CourseGroup
             {
                 CourseGroupId = 2,
                 CourseGroupTitle = "زامارین Xamarin",
                 IsDeleted = false,
                 ParentId = 1
             },

             new CourseGroup
             {
                 CourseGroupId = 3,
                 CourseGroupTitle = "React Native",
                 IsDeleted = false,
                 ParentId = 1
             },


             new CourseGroup
             {
                 CourseGroupId = 5,
                 CourseGroupTitle = "برنامه نویسی وب",
                 IsDeleted = false,
                 ParentId = null
             },

             new CourseGroup
             {
                 CourseGroupId = 6,
                 CourseGroupTitle = "ASP.net WebForms",
                 IsDeleted = false,
                 ParentId = 5
             },

             new CourseGroup
             {
                 CourseGroupId = 7,
                 CourseGroupTitle = "ASP.net MVC",
                 IsDeleted = false,
                 ParentId = 5
             },

             new CourseGroup
             {
                 CourseGroupId = 8,
                 CourseGroupTitle = "PHP MVC",
                 IsDeleted = false,
                 ParentId = 5
             },

             new CourseGroup
             {
                 CourseGroupId = 9,
                 CourseGroupTitle = "ASP.net Core",
                 IsDeleted = false,
                 ParentId = 5
             },

             new CourseGroup
             {
                 CourseGroupId = 10,
                 CourseGroupTitle = "برنامه نویسی تحت ویندوز",
                 IsDeleted = false,
                 ParentId = null
             },

             new CourseGroup
             {
                 CourseGroupId = 11,
                 CourseGroupTitle = "سی شارپ C#",
                 IsDeleted = false,
                 ParentId = 10
             },

             new CourseGroup
             {
                 CourseGroupId = 12,
                 CourseGroupTitle = "جاوا Java",
                 IsDeleted = false,
                 ParentId = 10
             },

             new CourseGroup
             {
                 CourseGroupId = 13,
                 CourseGroupTitle = "Node JS",
                 IsDeleted = false,
                 ParentId = 10
             },

             new CourseGroup
             {
                 CourseGroupId = 14,
                 CourseGroupTitle = "بانک های اطلاعاتی",
                 IsDeleted = false,
                 ParentId = null
             },

             new CourseGroup
             {
                 CourseGroupId = 15,
                 CourseGroupTitle = "SQL Server",
                 IsDeleted = false,
                 ParentId = 14
             },

             new CourseGroup
             {
                 CourseGroupId = 16,
                 CourseGroupTitle = "No SQL",
                 IsDeleted = false,
                 ParentId = 14
             },

             new CourseGroup
             {
                 CourseGroupId = 17,
                 CourseGroupTitle = "My SQL",
                 IsDeleted = false,
                 ParentId = 14
             },

             new CourseGroup
             {
                 CourseGroupId = 18,
                 CourseGroupTitle = "طراحی سایت",
                 IsDeleted = false,
                 ParentId = null
             },

             new CourseGroup
             {
                 CourseGroupId = 19,
                 CourseGroupTitle = "Bootstrap",
                 IsDeleted = false,
                 ParentId = 18
             },

             new CourseGroup
             {
                 CourseGroupId = 20,
                 CourseGroupTitle = "JQuery",
                 IsDeleted = false,
                 ParentId = 18
             },

             new CourseGroup
             {
                 CourseGroupId = 21,
                 CourseGroupTitle = "Java Script",
                 IsDeleted = false,
                 ParentId = 18
             }

             );

            #endregion

            #region SeedCourseLevel

            modelBuilder.Entity<CourseLevel>().HasData(
                new CourseLevel()
                {
                    CourseLevelId = 1,
                    CourseLevelTitle = "مبتدی"
                },
                new CourseLevel()
                {
                    CourseLevelId = 2,
                    CourseLevelTitle = "متوسط"
                },
                new CourseLevel()
                {
                    CourseLevelId = 3,
                    CourseLevelTitle = "پیشرفته"
                }
                );

            #endregion

            #region seedCourseStatus

            modelBuilder.Entity<CourseStatus>().HasData(
                new CourseStatus()
                {
                    CourseStatusId = 1,
                    CourseStatusTitle = "درحال ثبت نام"
                },
                new CourseStatus
                {
                    CourseStatusId = 2,
                    CourseStatusTitle = "در حال برگزاری"
                },
                new CourseStatus
                {
                    CourseStatusId = 3,
                    CourseStatusTitle = "اتمام دوره"
                }
                );

            #endregion


            #endregion

        }
    }
    #endregion


}
