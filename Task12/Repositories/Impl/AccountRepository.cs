using Domain;
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
        private readonly DataContext _context;
        private readonly DbSet<IdentityUserRole<string>> _entities;

        public AccountRepository(DataContext context)
        {
            _context = context;
            _entities = _context.Set<IdentityUserRole<string>>();
        }

        public bool isAdmin(User user)
        {
            return _entities.Where(item => item.RoleId == Constants.DefaultAdminID && item.UserId == user.Id).Any();
        }
    }
}
