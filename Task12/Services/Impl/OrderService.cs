using Domain;
using Repositories;
using Services.Dto;
using System;
using System.Collections.Generic;

namespace Services.Impl
{
    public class OrderService : IOrderService
    {
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderService(
            IUserTypeRepository userTypeRepository,
            IOrderRepository orderRepository)
        {
            _userTypeRepository = userTypeRepository;
            _orderRepository = orderRepository;
        }

        public IEnumerable<OrderDto> GetAll(User user, string typeName = null, int start = 0, int limit = 0)
        {
            OrderType typeFromDB = string.IsNullOrEmpty(typeName) ? null : _userTypeRepository.GetByName(user, typeName);
            IEnumerable<Order> orders = _orderRepository.GetAll(user, typeFromDB, start, limit);
            List<OrderDto> result = new List<OrderDto>();
            foreach (Order order in orders)
            {
                result.Add(Mapper.OrderToDto(order));
            }
            return result;
        }

        public IEnumerable<OrderDto> GetAllFromPeriod(User user, DateTime startTime, DateTime endTime,
            string typeName = null, int start = 0, int limit = 0)
        {
            OrderType typeFromDB = string.IsNullOrEmpty(typeName) ? null : _userTypeRepository.GetByName(user, typeName);
            IEnumerable<Order> orders = _orderRepository.GetAll(user, startTime, endTime, typeFromDB, start, limit);
            List<OrderDto> result = new List<OrderDto>();
            foreach (Order order in orders)
            {
                result.Add(Mapper.OrderToDto(order));
            }
            return result;
        }

        public int CountAll(User user, string typeName = null)
        {
            OrderType typeFromDB = string.IsNullOrEmpty(typeName) ? null : _userTypeRepository.GetByName(user, typeName);
            return _orderRepository.CountAll(user, typeFromDB);
        }

        public int CountAllFromPeriod(User user, DateTime startTime, DateTime endTime, string typeName)
        {
            OrderType typeFromDB = string.IsNullOrEmpty(typeName) ? null : _userTypeRepository.GetByName(user, typeName);
            return _orderRepository.CountAll(user, startTime, endTime, typeFromDB);
        }

        public OrderDto Get(User user, int id)
        {
            Order orderFromDB = _orderRepository.Get(id);
            if (orderFromDB.UserId == user.Id)
            {
                return Mapper.OrderToDto(orderFromDB);
            }
            else
            {
                throw new UnauthorizedAccessException();
            }
        }

        public void InsertOrder(User user, OrderDto order)
        {
            if (order == null || string.IsNullOrEmpty(order.TypeName) || order.Amount <= 0.0M)
                throw new ArgumentNullException();

            OrderType typeFromDB = _userTypeRepository.GetByName(user, order.TypeName);
            if (typeFromDB == null)
                throw new ArgumentException("Type is not exist");

            Order entity = new Order
            {
                Amount = order.Amount,
                Describe = order.Describe,
                OrderTime = DateTime.Now,
                Owner = user,
                UserId = user.Id,
                Type = typeFromDB,
                TypeId = typeFromDB.Id
            };

            _orderRepository.Insert(entity);
        }

        public void UpdateOrder(User user, OrderDto order, int id)
        {
            if (order == null || string.IsNullOrEmpty(order.TypeName) || order.Amount <= 0.0M)
                throw new ArgumentNullException();

            Order orderFromDB = _orderRepository.Get(id);
            if (orderFromDB == null)
                throw new ArgumentException("Order with Id: " + id + " is not exist");

            if (orderFromDB.UserId != user.Id)
                throw new UnauthorizedAccessException();

            OrderType typeFromDB = _userTypeRepository.GetByName(user, order.TypeName);
            if (typeFromDB == null)
                throw new ArgumentException("Type is not exist");

            orderFromDB.Amount = order.Amount;
            orderFromDB.Describe = order.Describe;
            orderFromDB.Type = typeFromDB;
            orderFromDB.TypeId = typeFromDB.Id;

            _orderRepository.Update(orderFromDB);
        }

        public void DeleteOrder(User user, int id)
        {
            Order orderFromDB = _orderRepository.Get(id);
            if (orderFromDB == null)
                throw new ArgumentException("Type with Id: " + id + " is not exist");

            if (orderFromDB.UserId != user.Id)
            {
                throw new UnauthorizedAccessException();
            }

            _orderRepository.Delete(orderFromDB);
        }
    }
}
