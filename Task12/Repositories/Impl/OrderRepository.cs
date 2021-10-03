using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Impl
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        private readonly DbSet<Order> _entities;

        public OrderRepository(DataContext context)
        {
            _context = context;
            _entities = _context.Set<Order>();
        }

        public IEnumerable<Order> GetAll(User user, OrderType type = null, int start = 0, int limit = 0)
        {
            if (start > 0 && limit > 0)
            {
                return _entities
                    .Where(item => (item.UserId == user.Id || item.UserId == _context.SystemUser.Id) &&
                        (type != null ? item.Type == type : true))
                    .Skip(start).Take(limit);
            }
            return _entities.Where(item => (item.UserId == user.Id || item.UserId == _context.SystemUser.Id) && item.Type == type);
        }

        public IEnumerable<Order> GetAll(User user,
                                        DateTime startTime, DateTime endTime,
                                        OrderType type = null, int start = 0, int limit = 0)
        {
            if (start > 0 && limit > 0)
            {
                return _entities.Where(item =>
                    (item.UserId == user.Id || item.UserId == _context.SystemUser.Id)
                    &&
                    (type != null ? item.Type == type : true)
                    &&
                    (item.OrderTime >= startTime && item.OrderTime <= endTime)
                    ).Skip(start).Take(limit);
            }
            return _entities.Where(item =>
                    (item.UserId == user.Id || item.UserId == _context.SystemUser.Id)
                    &&
                    (type != null ? item.Type == type : true)
                    &&
                    (item.OrderTime >= startTime && item.OrderTime <= endTime));
        }

        public int CountAll(User user, OrderType type)
        {
            return _entities
                    .Where(item => item.UserId == user.Id && (type != null ? item.Type == type : true)).Count();
        }

        public int CountAll(User user, DateTime startTime, DateTime endTime, OrderType type)
        {
            return _entities
                    .Where(item => item.UserId == user.Id && item.OrderTime >= startTime && item.OrderTime <= endTime &&
                        (type != null ? item.Type == type : true)).Count();
        }

        public decimal SumByType(User user, OrderType type)
        {
            return _entities.Where(item => item.UserId == user.Id && item.TypeId == type.Id).Sum(item => item.Amount);
        }

        public decimal SumByType(User user, OrderType type, DateTime startTime, DateTime endTime)
        {
            return _entities.Where(item => item.UserId == user.Id && item.TypeId == type.Id &&
                                    item.OrderTime >= startTime && item.OrderTime <= endTime)
                                    .Sum(item => item.Amount);
        }

        public Order Get(int id)
        {
            return _entities.Where(item => item.Id == id).FirstOrDefault();
        }

        public void Insert(Order order)
        {
            _entities.Add(order);
            _context.SaveChanges();
        }

        public void Update(Order order)
        {
            _entities.Update(order);
            _context.SaveChanges();
        }

        public void Delete(Order order)
        {
            _entities.Remove(order);
            _context.SaveChanges();
        }
    }
}
