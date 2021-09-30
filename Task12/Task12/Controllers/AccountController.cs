using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task12.Authentication;

namespace Task12
{
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager, 
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<bool> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { FirstName = model.FirstName, LastName = model.LastName, 
                    Email = model.Email, UserName = model.UserName };
                // добавляем пользователя
                await _roleManager.CreateAsync(new IdentityRole(Constants.DefaultAdminRole));
                var create = await _userManager.CreateAsync(user, model.Password);
                var addUserRole = await _userManager.AddToRoleAsync(user, Constants.DefaultUserRole);
                if (create.Succeeded && addUserRole.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new ArgumentException("Request is not valid");
            }
        }

        [HttpPost]
        [Route("login")]
        //[ValidateAntiForgeryToken]
        public async Task<bool> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                return result.Succeeded;
            }
            else
            {
                throw new ArgumentException("Request is not valid");
            }
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
        }
    }
}
