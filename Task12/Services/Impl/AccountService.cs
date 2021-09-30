using Domain;
using Microsoft.AspNetCore.Identity;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAccountRepository _accountRepository;

        public AccountService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IAccountRepository accountRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _accountRepository = accountRepository;
        }

        public User GetByUserName(string userName)
        {
            return _accountRepository.Get(userName);
        }

        public async ValueTask<bool> IsAdmin(User user)
        {
            IList<string> roles = await _userManager.GetRolesAsync(user);
            foreach (string role in roles)
            {
                if (Constants.DefaultAdminRole == role)
                    return true;
            }
            return false;
        }
    }
}
