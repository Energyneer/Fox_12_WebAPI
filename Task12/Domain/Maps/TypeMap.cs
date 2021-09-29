using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Maps
{
    public class TypeMap
    {
        public TypeMap(EntityTypeBuilder<OrderType> entityBuilder)
        {
            entityBuilder.HasKey(item => item.Id);
            entityBuilder.Property(item => item.OperationCategory).IsRequired();
            entityBuilder.Property(item => item.Name).IsRequired();
            entityBuilder.HasOne(item => item.Owner).WithMany(item => item.Types).HasForeignKey(item => item.UserId);
            entityBuilder.HasMany(item => item.Orders).WithOne(item => item.Type);
        }
    }
}
