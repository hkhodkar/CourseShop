using CourseShop.Core.Interfaces;
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

        public void AddRolePermission(int roleId, int permissionId)
        {
            var rolePermission = new RolePermission
            {
                PermissionId = permissionId,
                RoleId = roleId
            };
            _context.RolePermissions.Add(rolePermission);
            _context.SaveChanges();
        }

        public List<int> GetRolesPermission(int roleId)
        {
            return _context.RolePermissions.Where(r => r.RoleId == roleId).Select(r => r.PermissionId).ToList();
        }
    }
}
