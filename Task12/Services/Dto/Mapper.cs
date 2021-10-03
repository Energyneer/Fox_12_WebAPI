using Domain;

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

        public static User UserFromDto(RegisterRequest request)
        {
            return new User
            {
                UserName = request.UserName,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName
            };
        }
    }
}
