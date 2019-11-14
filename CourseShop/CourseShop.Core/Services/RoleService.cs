using CourseShop.Core.Interfaces;
using CourseShop.DataLayer.Context;
using CourseShop.DataLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseShop.Core.Services
{
    public class RoleService : IRoleService
    {

        private readonly CourseShopContext _context;

        public RoleService(CourseShopContext context)
        {
            _context = context;
        }
        public List<Role> GetRolesList()
        {
            return _context.Roles.ToList();
        }

        public async void AddUserRole(int userId , int roleId)
        {
            UserRole userRole = new UserRole
            {
                RoleId = roleId,
                UserId = userId
            };
           await _context.UserRoles.AddAsync(userRole);
            _context.SaveChanges();
        }

        public async void UpdateUserRoles(int userId, List<int> roles)
        {
            var OldRoles =  _context.UserRoles.Where(r => r.UserId == userId).ToList();
            foreach(var role in OldRoles)
            {
                _context.UserRoles.Remove(role);
                _context.SaveChanges();
            }

            foreach(var item in roles)
            {
                UserRole userRole = new UserRole
                {
                    RoleId = item,
                    UserId = userId
                };
                await _context.UserRoles.AddAsync(userRole);
                _context.SaveChanges();
            }

        }



    }
}
