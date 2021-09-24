using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class StandartType : BaseEntity
    {
        public BaseType OperationType { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
    }

    public enum BaseType
    {
        INCOME,
        SPENDING
    }
}
