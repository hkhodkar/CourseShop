﻿using CourseShop.Core.Interfaces;
using CourseShop.DataLayer.Context;
using CourseShop.DataLayer.Entity;
using System.Collections.Generic;
using System.Linq;

namespace CourseShop.Core.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly CourseShopContext _context;

        public PermissionService(CourseShopContext context)
        {
            _context = context;
        }

        public List<Permission> PermissionList()
        {
            return _context.Permissions.ToList();

        }

        public void AddRolePermission(int roleId, List<int> permissionIdList)
        {
            foreach (var permissionId in permissionIdList)
            {

                var rolePermission = new RolePermission
                {
                    PermissionId = permissionId,
                    RoleId = roleId
                };
                _context.RolePermissions.Add(rolePermission);
                _context.SaveChanges();
            }
        }

        public List<int> GetRolesPermission(int roleId)
        {
            return _context.RolePermissions.Where(r => r.RoleId == roleId).Select(r => r.PermissionId).ToList();
        }

        public void EditRolePermission(int roleId, List<int> permissionIdList)
        {
            _context.RolePermissions.Where(r => r.RoleId == roleId).ToList().ForEach(p => _context.RolePermissions.Remove(p));
            AddRolePermission(roleId, permissionIdList);
            _context.SaveChanges();
        }

        public bool CheckPermission(int permissionId, string username)
        {
            int userid = _context.Users.Single(u => u.Username == username).UserId;

            List<int> userRoles = _context.UserRoles.Where(u => u.UserId == userid).Select(r => r.RoleId).ToList();
            if (!userRoles.Any()) return false;

            List<int> RolePermission = _context.RolePermissions.Where(p => p.PermissionId == permissionId).Select(p => p.RoleId).ToList();

            return RolePermission.Any(p => userRoles.Contains(p));
        }
    }
}
