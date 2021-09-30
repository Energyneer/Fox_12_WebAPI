﻿using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Impl
{
    public class AccountRepository : IAccountRepository
    {
        public User SystemUser { get; }
        private readonly DataContext _context;
        private readonly DbSet<IdentityUserRole<string>> _userRoleEntities;
        private readonly DbSet<User> _userEntities;

        public AccountRepository(DataContext context)
        {
            _context = context;
            _userRoleEntities = _context.Set<IdentityUserRole<string>>();
            _userEntities = _context.Set<User>();
            SystemUser = _context.SystemUser;
        }

        public User Get(string userName)
        {
            return _userEntities.SingleOrDefault(item => item.UserName == userName);
        }

        public bool isAdmin(User user)
        {
            return _userRoleEntities.Where(item => item.RoleId == Constants.DefaultAdminID && item.UserId == user.Id).Any();
        }
    }
}
