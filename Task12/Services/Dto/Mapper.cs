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
        public static TypeDto TypeToDto(OrderType type)
        {
            return new TypeDto
            {
                Id = type.Id,
                Variety = TypeVariety.USER,
                OperationCategory = type.OperationCategory,
                Name = type.Name
            };
        }

        public static OrderType OrderTypeFromDto(User user, TypeDto type)
        {
            return new OrderType
            {
                OperationCategory = type.OperationCategory,
                Name = type.Name,
                UserId = user.Id,
                Owner = user
            };
        }

        public static OrderDto OrderToDto(Order order)
        {
            return new OrderDto
            {
                ID = order.Id,
                OperationCategory = order.Type.OperationCategory,
                TypeName = order.Type.Name,
                OrderTime = order.OrderTime,
                Amount = order.Amount,
                Describe = order.Describe
            };
        }
    }
}
