using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Maps
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(item => item.Id);
            entityBuilder.Property(item => item.Email).IsRequired();
            entityBuilder.Property(item => item.PasswordHash).IsRequired();
            entityBuilder.Property(item => item.UserName).IsRequired();
            entityBuilder.HasMany(item => item.Types).WithOne(item => item.Owner);
            entityBuilder.HasMany(item => item.Orders).WithOne(item => item.Owner);
        }
    }
}
