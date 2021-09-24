using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserType : BaseEntity
    {
        public BaseType OperationType { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
        public virtual User Owner { get; set; }
    }
}
