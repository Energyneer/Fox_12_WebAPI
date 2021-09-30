using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CountController : ControllerBase
    {
        private IOrderService _orderService;
        private IAccountService _accountService;

        public CountController(IOrderService orderService, IAccountService accountService)
        {
            _orderService = orderService;
            _accountService = accountService;
        }

        [HttpGet]
        public int GetAll(string? typename, DateTime? timestart, DateTime? timeend)
        {
            User user = _accountService.GetByUserName(User.Identity.Name);
            if (timestart != null && timeend != null)
            {
                return _orderService.CountAllFromPeriod(user, timestart.Value, timeend.Value, typename);
            }
            else
            {
                return _orderService.CountAll(_accountService.GetByUserName(User.Identity.Name), typename);
            }
        }
    }
}
