using System;

namespace Domain
{
    public class Order : BaseEntity
    {
        public DateTime OrderTime { get; set; }
        public decimal Amount { get; set; }
        public string Describe { get; set; }
        public string UserId { get; set; }
        public int TypeId { get; set; }
        public virtual User Owner { get; set; }
        public virtual OrderType Type { get; set; }

    }
}
