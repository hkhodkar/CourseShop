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
    [Migration("20191102182716_addWalletTypeToDb")]
    partial class addWalletTypeToDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CourseShop.DataLayer.Entity.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleTitle")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CourseShop.DataLayer.Entity.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActivateCode");

                    b.Property<string>("AvatarName");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("IsActive");

                    b.Property<string>("PasswordHash");

                    b.Property<DateTime>("RegisterDate");

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
#pragma warning restore 612, 618
        }
    }
}
