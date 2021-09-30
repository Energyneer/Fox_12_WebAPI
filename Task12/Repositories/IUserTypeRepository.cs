using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IUserTypeRepository
    {
        IEnumerable<OrderType> GetAll(User user, bool standarts = true, bool users = true, 
            bool income = true, bool expend = true);
        OrderType Get(int id);
        OrderType GetByName(User user, string name);
        void Insert(OrderType type);
        void Update(OrderType type);
        void Delete(OrderType type);
    }
}
