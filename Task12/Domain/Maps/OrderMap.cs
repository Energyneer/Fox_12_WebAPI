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
            entityBuilder.HasKey(item => item.Id);
            entityBuilder.Property(item => item.OrderTime).IsRequired();
            entityBuilder.Property(item => item.Amount).IsRequired();
            entityBuilder.Property(item => item.Describe);
            entityBuilder.HasOne(item => item.Type).WithMany(item => item.Orders).HasForeignKey(item => item.TypeId);
            entityBuilder.HasOne(item => item.Owner).WithMany(item => item.Orders).HasForeignKey(item => item.UserId);
        }
    }
}
