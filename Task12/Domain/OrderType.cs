using System.Collections.Generic;

namespace Domain
{
    public class OrderType : BaseEntity
    {
        public Category OperationCategory { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual User Owner { get; set; }
    }

    public enum Category
    {
        INCOME,
        EXPENDITURE
    }
}
