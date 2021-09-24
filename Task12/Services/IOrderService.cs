using Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IOrderService
    {
        IEnumerable<OrderDto> GetAllUserOrders(string userName);
        IEnumerable<OrderDto> GetOrdersByPeriod(DateTime start, DateTime end, string userName);
        void InsertOrder(OrderDto order, string userName);
        void UpdateOrder(int ID, OrderDto order, string userName);
        void DeleteOrder(int ID, string userName);
    }
}
