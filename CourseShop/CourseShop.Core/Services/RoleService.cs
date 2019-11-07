﻿using CourseShop.Core.Interfaces;
using CourseShop.DataLayer.Context;
using CourseShop.DataLayer.Entity;
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

    }
}