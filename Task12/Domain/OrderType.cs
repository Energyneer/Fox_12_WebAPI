using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderType : BaseEntity
    {
        public Category OperationCategory { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }      // ForeignKey
        public virtual ICollection<Order> Orders { get; set; }
        public virtual User Owner { get; set; }
    }

    public enum Category
    {
        //[Description("INCOME")]
        INCOME,
        //[Description("EXPENDITURE")]
        EXPENDITURE
    }
}
