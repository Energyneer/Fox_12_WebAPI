﻿using Microsoft.AspNetCore.Authorization;
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
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        private IAccountService _accountService;

        public OrderController(IOrderService orderService, IAccountService accountService)
        {
            _orderService = orderService;
            _accountService = accountService;
        }

        [HttpGet]
        public IEnumerable<OrderDto> GetAll(string? typename, DateTime? timestart, DateTime? timeend, int start, int limit)
        {
            if (timestart != null && timeend != null)
            {
                return _orderService.GetAllFromPeriod(_accountService.GetByUserName(User.Identity.Name), 
                    timestart.Value, timeend.Value, typename, start, limit);
            }
            else
            {
                return _orderService.GetAll(_accountService.GetByUserName(User.Identity.Name), typename, start, limit);
            }
        }

        [HttpGet("{id}")]
        public OrderDto Get(int id)
        {
            return _orderService.Get(_accountService.GetByUserName(User.Identity.Name), id);
        }

        [HttpPost]
        public void Post(OrderDto order)
        {
            _orderService.InsertOrder(_accountService.GetByUserName(User.Identity.Name), order);
        }

        [HttpPut("{id}")]
        public void Put(int id, OrderDto order)
        {
            _orderService.UpdateOrder(_accountService.GetByUserName(User.Identity.Name), order, id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _orderService.DeleteOrder(_accountService.GetByUserName(User.Identity.Name), id);
        }
    }
}
