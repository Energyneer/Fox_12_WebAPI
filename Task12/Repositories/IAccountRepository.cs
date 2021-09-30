using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IAccountRepository
    {
        public User SystemUser { get; }
        User Get(string userName);
        bool isAdmin(User user);
    }
}
