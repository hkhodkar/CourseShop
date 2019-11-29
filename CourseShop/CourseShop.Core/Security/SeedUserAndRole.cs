using CourseShop.Core.Interfaces;
using CourseShop.DataLayer.Context;
using CourseShop.DataLayer.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseShop.Core.Security
{



    public class SeedUserAndRole
    {

        public async static void Initialize(IServiceProvider serviceProvider, IApplicationBuilder app)
        {

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<CourseShopContext>();

                var _roleSeervice = serviceScope.ServiceProvider.GetRequiredService<IRoleService>();

                var _userService = serviceScope.ServiceProvider.GetRequiredService<IUserService>();

                var _permissionService = serviceScope.ServiceProvider.GetRequiredService<IPermissionService>();


                string[] roles = new string[] { "Owner", "Administrator", "Manager", "Teacher" };

                foreach (string role in roles)
                {

                    if (!context.Roles.Any(r => r.RoleTitle == role))
                    {
                       await context.Roles.AddRangeAsync(new Role
                        {
                            RoleTitle = role

                        });
                        context.SaveChanges();
                    }
                }


                var user = new User
                {
                    Username = "هاتف خودکار",
                    ActivateCode = Guid.NewGuid().ToString().Replace("-", ""),
                    Email = "hatef.khodkar@hotmail.com",
                    IsActive = true,
                    IsDeleted = false,
                    PasswordHash = "20-2C-B9-62-AC-59-07-5B-96-4B-07-15-2D-23-4B-70",
                    RegisterDate = DateTime.Now,
                    UserAvatar = "default.jpg",
                };


                if (!context.Users.Any(u => u.Username == user.Username))
                {
                    context.Users.Add(user);
                    await context.SaveChangesAsync();

                    List<int> rolesId = context.Roles.Select(r => r.RoleId).ToList();

                    AssignRoles(_userService, _roleSeervice, user.UserId, rolesId);


                    var roleId = _roleSeervice.GetRoleIdByRoleTitle("Owner");
                    List<int> permissionIdList = context.Permissions.Select(p => p.PermissionId).ToList();

                    AssignPermistionToRole(_permissionService, roleId, permissionIdList);

                  await  context.SaveChangesAsync();

                }
            }


        }
        public static void AssignRoles(IUserService _userService, IRoleService _roleSeervice, int userId, List<int> rolesId)
        {

            foreach (var item in rolesId)
            {
                _roleSeervice.AddUserRole(userId, item);
            }
        }

        public static void AssignPermistionToRole(IPermissionService _permissionService, int roleId, List<int> permissionIdList)
        {
            _permissionService.AddRolePermission(roleId, permissionIdList);
        }
    }

}

