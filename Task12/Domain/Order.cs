using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string UserId { get; set; }      // ForeignKey
        public int TypeId { get; set; }         // ForeignKey
        public virtual User Owner { get; set; }
        public virtual OrderType Type { get; set; }
        
    }
}
