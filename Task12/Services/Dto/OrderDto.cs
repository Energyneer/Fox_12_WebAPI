using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dto
{
    public class OrderDto
    {
        public int ID { get; set; }
        public Category OperationCategory { get; set; }
        public string TypeName { get; set; }
        public DateTime OrderTime { get; set; }
        public decimal Amount { get; set; }
        public string Describe { get; set; }
       
    }
}
