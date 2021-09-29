using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UsersRepositoryOLD
    {
        public User SystemUser { get; }
        private readonly DataContext context;
        protected readonly DbSet<User> entities;

        public UsersRepositoryOLD(DataContext context)
        {
            this.context = context;
            entities = context.Set<User>();
            SystemUser = context.SystemUser;
        }

        public User Get(string userName)
        {
            return entities.SingleOrDefault(item => item.UserName == userName);
        }
    }
}
