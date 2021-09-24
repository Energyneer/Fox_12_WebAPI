using Domain;
using Domain.Maps;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new StandartTypeMap(modelBuilder.Entity<StandartType>());
            new UserTypeMap(modelBuilder.Entity<UserType>());
            new OrderMap(modelBuilder.Entity<Order>());
            base.OnModelCreating(modelBuilder);
        }
    }
}
