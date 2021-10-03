using Domain;
using Microsoft.AspNetCore.Identity;
using Repositories;
using Services.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAccountRepository _accountRepository;
        private readonly SignInManager<User> _signInManager;

        public AccountService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IAccountRepository accountRepository, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _accountRepository = accountRepository;
            _signInManager = signInManager;
        }

        public User GetByUserName(string userName)
        {
            return _accountRepository.Get(userName);
        }

        public async Task<AuthResult> RegisterUser(RegisterRequest request)
        {
            User checkedByName = _accountRepository.Get(request.UserName);
            User checkedByEmail = _accountRepository.GetByEmail(request.Email);
            if (checkedByName != null || checkedByEmail != null)
                throw new ArgumentException("User with this name or email is exist");

            User user = Mapper.UserFromDto(request);
            var create = await _userManager.CreateAsync(user, request.Password);
            var addUserRole = await _userManager.AddToRoleAsync(user, Constants.DefaultUserRole);
            if (create.Succeeded && addUserRole.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return new AuthResult { Status = "SUCCESSED", UserName = user.UserName, Email = user.Email };
            }
            else
            {
                return new AuthResult { Status = "FAILED", UserName = user.UserName, Email = user.Email };
            }
        }

        public async Task<AuthResult> Login(LoginRequest request)
        {
            var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, request.RememberMe, false);
            if (result.Succeeded)
            {
                return new AuthResult { Status = "SUCCESSED", UserName = request.UserName };
            }
            else
            {
                return new AuthResult { Status = "FAILED", UserName = request.UserName };
            }
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
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
