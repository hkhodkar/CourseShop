﻿using CourseShop.DataLayer.Entity;
using System.Collections.Generic;

namespace CourseShop.Core.Interfaces
{
    public interface IRoleService
    {
        List<Role> GetRolesList();

        void AddUserRole(int userId, int roleId);

        void UpdateUserRoles(int userId, List<int> roles);

        int AddRole(Role role);

        Role GetRoleById(int id);

        IList<Role> GetDeleteRoleList();

        void RestoreRole(int id);

        void DeleteRole(int id);

        Role GetRoleByName(string roleTitle);

        int GetRoleIdByRoleTitle(string roleTitle);


    }
}
