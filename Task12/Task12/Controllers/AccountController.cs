using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Dto;
using System;
using System.Threading.Tasks;

namespace Task12
{
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<AuthResult> Register(RegisterRequest request)
        {
            if (ModelState.IsValid)
            {
                return await _accountService.RegisterUser(request);
            }
            else
            {
                throw new ArgumentException("Request is not valid");
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<AuthResult> Login(LoginRequest request)
        {
            if (ModelState.IsValid)
            {
                return await _accountService.Login(request);
            }
            else
            {
                throw new ArgumentException("Request is not valid");
            }
        }

        [HttpPost]
        public async Task Logout()
        {
            await _accountService.Logout();
        }
    }
}
