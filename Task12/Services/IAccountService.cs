using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IAccountService
    {
        User GetByUserName(string userName);
        ValueTask<bool> IsAdmin(User user);
    }
}
