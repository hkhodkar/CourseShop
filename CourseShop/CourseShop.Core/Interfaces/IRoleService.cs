﻿using CourseShop.DataLayer.Entity;
using System.Collections.Generic;

namespace CourseShop.Core.Interfaces
{
    public interface IRoleService
    {
        List<Role> GetRolesList();
    }
}