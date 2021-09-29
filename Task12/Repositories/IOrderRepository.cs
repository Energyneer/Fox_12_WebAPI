using Domain;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll(User user, OrderType type, int start, int limit);
        IEnumerable<Order> GetAll(User user, DateTime startTime, DateTime endTime, OrderType type, int start, int limit);
        Order Get(int id);
        void Insert(Order order);
        void Update(Order order);
        void Delete(Order order);
    }
}
