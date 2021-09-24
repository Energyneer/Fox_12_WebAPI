using Microsoft.AspNetCore.Authorization;
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

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<OrderDto> Get()
        {
            return _orderService.GetAllUserOrders(User.Identity.Name);
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post(OrderDto order)
        {
            _orderService.InsertOrder(order, User.Identity.Name);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, OrderDto order)
        {
            _orderService.UpdateOrder(id, order, User.Identity.Name);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _orderService.DeleteOrder(id, User.Identity.Name);
        }
    }
}
