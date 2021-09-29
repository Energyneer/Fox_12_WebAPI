using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Impl
{
    public class UserTypeRepository : IUserTypeRepository
    {
        private readonly DataContext _context;
        private readonly DbSet<OrderType> _entities;

        public UserTypeRepository(DataContext context)
        {
            _context = context;
            _entities = _context.Set<OrderType>();
        }

        public IEnumerable<OrderType> GetAll(User user, 
                                            bool standarts = true, bool users = true, 
                                            bool income = true, bool expend = true)
        {
            return _entities.Where(item => (
                standarts ^ users ? 
                    (standarts ? item.UserId == _context.SystemUser.Id : item.UserId == user.Id) : 
                    item.UserId == user.Id || item.UserId == _context.SystemUser.Id) 
                    && 
                (income ^ expend ?
                    (income ? item.OperationCategory == Category.INCOME : item.OperationCategory == Category.EXPENDITURE) :
                    true));
        }

        public OrderType Get(int id)
        {
            return _entities.Where(item => item.Id == id).FirstOrDefault();
        }

        public OrderType GetByName(User user, string name)
        {
            return _entities.Where(item => (item.UserId == user.Id || item.UserId == _context.SystemUser.Id)
                    && item.Name == name).FirstOrDefault();
        }

        public void Insert(OrderType type)
        {
            _entities.Add(type);
            _context.SaveChanges();
        }

        public void Update(OrderType type)
        {
            _entities.Update(type);
            _context.SaveChanges();
        }

        public void Delete(OrderType type)
        {
            _entities.Remove(type);
            _context.SaveChanges();
        }
    }
}
