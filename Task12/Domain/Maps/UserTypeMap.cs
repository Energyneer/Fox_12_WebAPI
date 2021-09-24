using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Maps
{
    public class UserTypeMap
    {
        public UserTypeMap(EntityTypeBuilder<UserType> entityBuilder)
        {
            entityBuilder.HasKey(item => item.ID);
            entityBuilder.Property(item => item.OperationType).IsRequired();
            entityBuilder.Property(item => item.Name).IsRequired();
            entityBuilder.HasMany(item => item.Orders).WithOne(item => item.UserOrderType);
        }
    }
}
