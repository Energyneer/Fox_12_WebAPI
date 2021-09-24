using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Order : BaseEntity
    {
        public DateTime OrderTime { get; set; }
        public decimal Amount { get; set; }
        public string Describe { get; set; }
        public virtual StandartType StandartOrderType { get; set; }
        public virtual UserType UserOrderType { get; set; }
        public virtual User Owner { get; set; }
    }
}
