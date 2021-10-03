using Domain;
using System;

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
