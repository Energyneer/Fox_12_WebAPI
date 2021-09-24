using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Maps
{
    public class StandartTypeMap
    {
        public StandartTypeMap(EntityTypeBuilder<StandartType> entityBuilder)
        {
            entityBuilder.HasKey(item => item.ID);
            entityBuilder.Property(item => item.OperationType).IsRequired();
            entityBuilder.Property(item => item.Name).IsRequired();
            entityBuilder.HasMany(item => item.Orders).WithOne(item => item.StandartOrderType);
            entityBuilder.HasData(new StandartType[]
            {
                new StandartType{ ID = 1, OperationType = BaseType.INCOME, Name = "Salary" },
                new StandartType{ ID = 2, OperationType = BaseType.INCOME, Name = "Interest" },
                new StandartType{ ID = 3, OperationType = BaseType.INCOME, Name = "Selling" },
                new StandartType{ ID = 4, OperationType = BaseType.INCOME, Name = "Investments" },
                new StandartType{ ID = 5, OperationType = BaseType.INCOME, Name = "Gifts" },
                new StandartType{ ID = 6, OperationType = BaseType.INCOME, Name = "Allowance" },

                new StandartType{ ID = 7, OperationType = BaseType.SPENDING, Name = "Housing" },
                new StandartType{ ID = 8, OperationType = BaseType.SPENDING, Name = "Transportation" },
                new StandartType{ ID = 9, OperationType = BaseType.SPENDING, Name = "Food" },
                new StandartType{ ID = 10, OperationType = BaseType.SPENDING, Name = "Utilities" },
                new StandartType{ ID = 11, OperationType = BaseType.SPENDING, Name = "Healthcare" },
                new StandartType{ ID = 12, OperationType = BaseType.SPENDING, Name = "Investing" }
            });
        }
    }
}
