﻿// <auto-generated />
using System;
using CourseShop.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CourseShop.DataLayer.Migrations
{
    [DbContext(typeof(CourseShopContext))]
    [Migration("20191206133351_addCourseLevel.")]
    partial class addCourseLevel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CourseShop.DataLayer.Entity.Courses.CourseGroup", b =>
                {
                    b.Property<int>("CourseGroupId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseGroupTitle")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ParentId");

                    b.HasKey("CourseGroupId");

                    b.HasIndex("ParentId");

                    b.ToTable("CourseGroup");

                    b.HasData(
                        new
                        {
                            CourseGroupId = 1,
                            CourseGroupTitle = "برنامه نویسی موبایل",
                            IsDeleted = false
                        },
                        new
                        {
                            CourseGroupId = 2,
                            CourseGroupTitle = "زامارین Xamarin",
                            IsDeleted = false,
                            ParentId = 1
                        },
                        new
                        {
                            CourseGroupId = 3,
                            CourseGroupTitle = "React Native",
                            IsDeleted = false,
                            ParentId = 1
                        },
                        new
                        {
                            CourseGroupId = 5,
                            CourseGroupTitle = "برنامه نویسی وب",
                            IsDeleted = false
                        },
                        new
                        {
                            CourseGroupId = 6,
                            CourseGroupTitle = "ASP.net WebForms",
                            IsDeleted = false,
                            ParentId = 5
                        },
                        new
                        {
                            CourseGroupId = 7,
                            CourseGroupTitle = "ASP.net MVC",
                            IsDeleted = false,
                            ParentId = 5
                        },
                        new
                        {
                            CourseGroupId = 8,
                            CourseGroupTitle = "PHP MVC",
                            IsDeleted = false,
                            ParentId = 5
                        },
                        new
                        {
                            CourseGroupId = 9,
                            CourseGroupTitle = "ASP.net Core",
                            IsDeleted = false,
                            ParentId = 5
                        },
                        new
                        {
                            CourseGroupId = 10,
                            CourseGroupTitle = "برنامه نویسی تحت ویندوز",
                            IsDeleted = false
                        },
                        new
                        {
                            CourseGroupId = 11,
                            CourseGroupTitle = "سی شارپ C#",
                            IsDeleted = false,
                            ParentId = 10
                        },
                        new
                        {
                            CourseGroupId = 12,
                            CourseGroupTitle = "جاوا Java",
                            IsDeleted = false,
                            ParentId = 10
                        },
                        new
                        {
                            CourseGroupId = 13,
                            CourseGroupTitle = "Node JS",
                            IsDeleted = false,
                            ParentId = 10
                        },
                        new
                        {
                            CourseGroupId = 14,
                            CourseGroupTitle = "بانک های اطلاعاتی",
                            IsDeleted = false
                        },
                        new
                        {
                            CourseGroupId = 15,
                            CourseGroupTitle = "SQL Server",
                            IsDeleted = false,
                            ParentId = 14
                        },
                        new
                        {
                            CourseGroupId = 16,
                            CourseGroupTitle = "No SQL",
                            IsDeleted = false,
                            ParentId = 14
                        },
                        new
                        {
                            CourseGroupId = 17,
                            CourseGroupTitle = "My SQL",
                            IsDeleted = false,
                            ParentId = 14
                        },
                        new
                        {
                            CourseGroupId = 18,
                            CourseGroupTitle = "طراحی سایت",
                            IsDeleted = false
                        },
                        new
                        {
                            CourseGroupId = 19,
                            CourseGroupTitle = "Bootstrap",
                            IsDeleted = false,
                            ParentId = 18
                        },
                        new
                        {
                            CourseGroupId = 20,
                            CourseGroupTitle = "JQuery",
                            IsDeleted = false,
                            ParentId = 18
                        },
                        new
                        {
                            CourseGroupId = 21,
                            CourseGroupTitle = "Java Script",
                            IsDeleted = false,
                            ParentId = 18
                        });
                });

            modelBuilder.Entity("CourseShop.DataLayer.Entity.Courses.CourseLevel", b =>
                {
                    b.Property<int>("CourseLevelId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseLevelTitle")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("CourseLevelId");

                    b.ToTable("CourseLevel");

                    b.HasData(
                        new
                        {
                            CourseLevelId = 1,
                            CourseLevelTitle = "مبتدی"
                        },
                        new
                        {
                            CourseLevelId = 2,
                            CourseLevelTitle = "متوسط"
                        },
                        new
                        {
                            CourseLevelId = 3,
                            CourseLevelTitle = "پیشرفته"
                        });
                });

            modelBuilder.Entity("CourseShop.DataLayer.Entity.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ParrentId");

                    b.Property<string>("PermissionNameForAttribute")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("PermissionTitle")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("PermissionId");

                    b.HasIndex("ParrentId");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            PermissionId = 1,
                            PermissionNameForAttribute = "admin panel",
                            PermissionTitle = "پنل مدیریت"
                        },
                        new
                        {
                            PermissionId = 2,
                            ParrentId = 1,
                            PermissionNameForAttribute = "user management",
                            PermissionTitle = "مدیریت کاربران"
                        },
                        new
                        {
                            PermissionId = 3,
                            ParrentId = 2,
                            PermissionNameForAttribute = "add user",
                            PermissionTitle = "اضافه کردن کاربر"
                        },
                        new
                        {
                            PermissionId = 4,
                            ParrentId = 2,
                            PermissionNameForAttribute = "edit user",
                            PermissionTitle = "ویرایش  کاربر"
                        },
                        new
                        {
                            PermissionId = 5,
                            ParrentId = 2,
                            PermissionNameForAttribute = "delete user",
                            PermissionTitle = "حذف  کاربر"
                        },
                        new
                        {
                            PermissionId = 6,
                            ParrentId = 1,
                            PermissionNameForAttribute = "role management",
                            PermissionTitle = "مدیریت نقش ها"
                        },
                        new
                        {
                            PermissionId = 7,
                            ParrentId = 6,
                            PermissionNameForAttribute = "add user",
                            PermissionTitle = "اضافه کردن نقش"
                        },
                        new
                        {
                            PermissionId = 8,
                            ParrentId = 6,
                            PermissionNameForAttribute = "edit user",
                            PermissionTitle = "ویرایش  نقش"
                        },
                        new
                        {
                            PermissionId = 9,
                            ParrentId = 6,
                            PermissionNameForAttribute = "delete user",
                            PermissionTitle = "حذف  نقش"
                        });
                });

            modelBuilder.Entity("CourseShop.DataLayer.Entity.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("RoleTitle")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CourseShop.DataLayer.Entity.RolePermission", b =>
                {
                    b.Property<int>("RP_Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PermissionId");

                    b.Property<int>("RoleId");

                    b.HasKey("RP_Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("CourseShop.DataLayer.Entity.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActivateCode");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("PasswordHash");

                    b.Property<DateTime>("RegisterDate");

                    b.Property<string>("UserAvatar");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CourseShop.DataLayer.Entity.UserRole", b =>
                {
                    b.Property<int>("USR_RoleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId");

                    b.Property<int>("UserId");

                    b.HasKey("USR_RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("CourseShop.DataLayer.Entity.Wallet", b =>
                {
                    b.Property<int>("WalletId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<bool>("IsPay");

                    b.Property<int>("TypeId");

                    b.Property<int>("UserId");

                    b.HasKey("WalletId");

                    b.HasIndex("TypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("CourseShop.DataLayer.Entity.WalletType", b =>
                {
                    b.Property<int>("TypeId");

                    b.Property<string>("TypeTitle")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("TypeId");

                    b.ToTable("WalletTypes");

                    b.HasData(
                        new
                        {
                            TypeId = 1,
                            TypeTitle = "واریز"
                        },
                        new
                        {
                            TypeId = 2,
                            TypeTitle = "برداشت"
                        });
                });

            modelBuilder.Entity("CourseShop.DataLayer.Entity.Courses.CourseGroup", b =>
                {
                    b.HasOne("CourseShop.DataLayer.Entity.Courses.CourseGroup")
                        .WithMany("CourseGroupsCourseGroups")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("CourseShop.DataLayer.Entity.Permission", b =>
                {
                    b.HasOne("CourseShop.DataLayer.Entity.Permission")
                        .WithMany("Permissions")
                        .HasForeignKey("ParrentId");
                });

            modelBuilder.Entity("CourseShop.DataLayer.Entity.RolePermission", b =>
                {
                    b.HasOne("CourseShop.DataLayer.Entity.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CourseShop.DataLayer.Entity.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CourseShop.DataLayer.Entity.UserRole", b =>
                {
                    b.HasOne("CourseShop.DataLayer.Entity.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CourseShop.DataLayer.Entity.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CourseShop.DataLayer.Entity.Wallet", b =>
                {
                    b.HasOne("CourseShop.DataLayer.Entity.WalletType", "WalletType")
                        .WithMany("Wallets")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CourseShop.DataLayer.Entity.User", "User")
                        .WithMany("Wallets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
