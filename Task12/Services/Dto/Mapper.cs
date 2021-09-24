using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dto
{
    public class Mapper
    {
        public static TypeDto TypeToDto(StandartType type)
        {
            return new TypeDto
            {
                //OperationType = type.OperationType,
                Name = type.Name
            };
        }

        public static TypeDto TypeToDto(UserType type)
        {
            return new TypeDto
            {
                //OperationType = type.OperationType,
                Name = type.Name
            };
        }

        public static UserType TypeFromDto(TypeDto type, User user)
        {
            return new UserType
            {
                //OperationType = type.OperationType,
                Name = type.Name,
                Owner = user
            };
        }

        public static OrderDto OrderToDto(Order order)
        {
            return new OrderDto
            {
                ID = order.ID,
                OperationType = order.UserOrderType.OperationType,
                TypeName = order.StandartOrderType != null ? order.StandartOrderType.Name : order.UserOrderType.Name,
                OrderTime = order.OrderTime,
                Amount = order.Amount,
                Describe = order.Describe
            };
        }
    }
}
