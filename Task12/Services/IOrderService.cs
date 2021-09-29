using Domain;
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
        IEnumerable<OrderDto> GetAll(User user, string typeName = null, int start = 0, int limit = 0);
        IEnumerable<OrderDto> GetAllFromPeriod(User user, DateTime startTime, DateTime endTime, 
            string typeName, int start, int limit);
        OrderDto Get(User user, int id);
        void InsertOrder(User user, OrderDto order);
        void UpdateOrder(User user, OrderDto order, int id);
        void DeleteOrder(User user, int id);
    }
}
