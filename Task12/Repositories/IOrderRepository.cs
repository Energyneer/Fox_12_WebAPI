using Domain;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll(User user, OrderType type, int start, int limit);
        IEnumerable<Order> GetAll(User user, DateTime startTime, DateTime endTime, OrderType type, int start, int limit);
        int CountAll(User user, OrderType type);
        int CountAll(User user, DateTime startTime, DateTime endTime, OrderType type);
        decimal SumByType(User user, OrderType type);
        decimal SumByType(User user, OrderType type, DateTime startTime, DateTime endTime);
        Order Get(int id);
        void Insert(Order order);
        void Update(Order order);
        void Delete(Order order);
    }
}
