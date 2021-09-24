using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UsersRepository
    {
        private readonly DataContext context;
        protected readonly DbSet<User> entities;

        public UsersRepository(DataContext context)
        {
            this.context = context;
            entities = context.Set<User>();
        }

        public User Get(string userName)
        {
            return entities.SingleOrDefault(item => item.UserName == userName);
        }
    }
}
