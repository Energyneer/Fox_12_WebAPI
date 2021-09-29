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
        public int GetAll(string? typename, DateTime? timestart, DateTime? timeend, int start, int limit)
        {
            if (timestart != null && timeend != null)
            {
                return _orderService.GetAllFromPeriod(_accountService.GetByUserName(User.Identity.Name),
                    timestart.Value, timeend.Value, typename, start, limit).Count();
            }
            else
            {
                return _orderService.GetAll(_accountService.GetByUserName(User.Identity.Name), typename, start, limit).Count();
            }
        }
    }
}
