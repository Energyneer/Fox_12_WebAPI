using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Domain
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<OrderType> Types { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
