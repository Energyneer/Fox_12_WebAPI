using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Maps
{
    public class OrderMap
    {
        public OrderMap(EntityTypeBuilder<Order> entityBuilder)
        {
            entityBuilder.HasKey(item => item.ID);
            entityBuilder.Property(item => item.OrderTime).IsRequired();
            entityBuilder.Property(item => item.Amount).IsRequired();
            entityBuilder.Property(item => item.Describe);
            entityBuilder.HasOne(item => item.StandartOrderType).WithMany(item => item.Orders);
            entityBuilder.HasOne(item => item.UserOrderType).WithMany(item => item.Orders);
        }
    }
}
