using Domain;
using Repositories;
using Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class OrderService : IOrderService
    {
        private UsersRepository _userIdentRepository;
        private IDataRepository<Order> _orderRepository;
        private IDataRepository<StandartType> _standartTypeRepository;
        private IDataRepository<UserType> _userTypeRepository;

        public OrderService(
            UsersRepository userIdentRepository, 
            IDataRepository<Order> orderRepository, 
            IDataRepository<StandartType> standartTypeRepository, 
            IDataRepository<UserType> userTypeRepository)
        {
            _userIdentRepository = userIdentRepository;
            _orderRepository = orderRepository;
            _standartTypeRepository = standartTypeRepository;
            _userTypeRepository = userTypeRepository;
        }

        public IEnumerable<OrderDto> GetAllUserOrders(string userName)
        {
            User user = _userIdentRepository.Get(userName);
            IEnumerable<Order> allOrders = from item in _orderRepository.GetAll() where (item.Owner == user) select item;
            List<OrderDto> result = new List<OrderDto>();
            foreach (Order order in allOrders)
            {
                result.Add(Mapper.OrderToDto(order));
            }
            return result;
        }

        public IEnumerable<OrderDto> GetOrdersByPeriod(DateTime start, DateTime end, string userName)
        {
            User user = _userIdentRepository.Get(userName);
            IEnumerable<Order> allOrders = from item in _orderRepository.GetAll() where 
                                           (item.Owner == user && 
                                           (item.OrderTime >= start && item.OrderTime <= end))
                                           select item;
            List<OrderDto> result = new List<OrderDto>();
            foreach (Order order in allOrders)
            {
                result.Add(Mapper.OrderToDto(order));
            }
            return result;
        }

        public void InsertOrder(OrderDto order, string userName)
        {
            User user = _userIdentRepository.Get(userName);
            StandartType standartType = (from item in _standartTypeRepository.GetAll() where item.Name == order.TypeName select item).FirstOrDefault();
            UserType userType = null;
            if (standartType == null)
                userType = (from item in _userTypeRepository.GetAll() where item.Name == order.TypeName select item).FirstOrDefault();

            if ((standartType != null || userType != null) && user != null)
                _orderRepository.Insert(new Order { 
                    StandartOrderType = standartType, 
                    UserOrderType = userType, 
                    OrderTime = DateTime.Now, 
                    Amount = order.Amount, 
                    Describe = order.Describe, 
                    Owner = user});
        }

        public void UpdateOrder(int ID, OrderDto order, string userName)
        {
            Order orderFromDB = _orderRepository.Get(ID);
            CheckAccessRights(orderFromDB, userName);

            orderFromDB.Amount = order.Amount;
            orderFromDB.Describe = order.Describe;
            _orderRepository.Update(orderFromDB);
        }

        public void DeleteOrder(int ID, string userName)
        {
            Order orderFromDB = _orderRepository.Get(ID);
            CheckAccessRights(orderFromDB, userName);
            _orderRepository.Delete(orderFromDB);
        }

        private void CheckAccessRights(Order order, string userName)
        {
            User user = _userIdentRepository.Get(userName);
            if (order.Owner != user)
                throw new UnauthorizedAccessException();
        }
    }
}
