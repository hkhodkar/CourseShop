using CourseShop.DataLayer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseShop.Core.Interfaces
{
    public interface IPermissionService
    {
        List<Permission> PermissionList();

        void AddRolePermission(int roleId, List<int> permissionId);

        List<int> GetRolesPermission(int roleId);

        void EditRolePermission(int roleId, List<int> permissionIdList);
    }
}
