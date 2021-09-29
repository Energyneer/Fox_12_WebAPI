using Domain;
using Domain.Maps;
using Microsoft.AspNetCore.Identity;
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
        public User SystemUser { get; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            SystemUser = new User
            {
                Id = Constants.DefaultSystemID,
                UserName = Constants.DefaultSystemName,
                NormalizedUserName = Constants.DefaultSystemName,
                Email = Constants.DefaultSystemEmail,
                NormalizedEmail = Constants.DefaultSystemEmail,
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, Constants.DefaultSystemPassword),
                SecurityStamp = string.Empty
            };
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserMap(modelBuilder.Entity<User>());
            new TypeMap(modelBuilder.Entity<OrderType>());
            new OrderMap(modelBuilder.Entity<Order>());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = Constants.DefaultSystemID,
                    Name = Constants.DefaultSystemRole,
                    NormalizedName = Constants.DefaultSystemRole
                },
                new IdentityRole 
                {
                    Id = Constants.DefaultAdminID,
                    Name = Constants.DefaultAdminRole,
                    NormalizedName = Constants.DefaultAdminRole
                }, 
                new IdentityRole 
                { 
                    Id = Constants.DefaultUserID,
                    Name = Constants.DefaultUserRole,
                    NormalizedName = Constants.DefaultUserRole
                });

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(new User[]
            {
                SystemUser,
                new User
                {
                    Id = Constants.DefaultAdminID,
                    UserName = Constants.DefaultAdminName,
                    NormalizedUserName = Constants.DefaultAdminName,
                    Email = Constants.DefaultAdminEmail,
                    NormalizedEmail = Constants.DefaultAdminEmail,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, Constants.DefaultAdminPassword),
                    SecurityStamp = string.Empty
                },
                new User
                {
                    Id = Constants.DefaultUserID,
                    UserName = Constants.DefaultUserName,
                    NormalizedUserName = Constants.DefaultUserName,
                    Email = Constants.DefaultUserEmail,
                    NormalizedEmail = Constants.DefaultUserEmail,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, Constants.DefaultUserPassword),
                    SecurityStamp = string.Empty
                }
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>[]
            {
                new IdentityUserRole<string>
                {
                    RoleId = Constants.DefaultSystemID,
                    UserId = Constants.DefaultSystemID
                },
                new IdentityUserRole<string>
                {
                    RoleId = Constants.DefaultAdminID,
                    UserId = Constants.DefaultAdminID
                },
                new IdentityUserRole<string>
                {
                    RoleId = Constants.DefaultUserID,
                    UserId = Constants.DefaultUserID
                }
            });

            modelBuilder.Entity<OrderType>().HasData(new OrderType[]
            {
                new OrderType{ Id = 1, OperationCategory = Category.INCOME, Name = "Salary", UserId = SystemUser.Id },
                new OrderType{ Id = 2, OperationCategory = Category.INCOME, Name = "Interest", UserId = SystemUser.Id },
                new OrderType{ Id = 3, OperationCategory = Category.INCOME, Name = "Selling", UserId = SystemUser.Id },
                new OrderType{ Id = 4, OperationCategory = Category.INCOME, Name = "Investments", UserId = SystemUser.Id },
                new OrderType{ Id = 5, OperationCategory = Category.INCOME, Name = "Gifts", UserId = SystemUser.Id },
                new OrderType{ Id = 6, OperationCategory = Category.INCOME, Name = "Allowance", UserId = SystemUser.Id },

                new OrderType{ Id = 7, OperationCategory = Category.EXPENDITURE, Name = "Housing", UserId = SystemUser.Id },
                new OrderType{ Id = 8, OperationCategory = Category.EXPENDITURE, Name = "Transportation", UserId = SystemUser.Id },
                new OrderType{ Id = 9, OperationCategory = Category.EXPENDITURE, Name = "Food", UserId = SystemUser.Id },
                new OrderType{ Id = 10, OperationCategory = Category.EXPENDITURE, Name = "Utilities", UserId = SystemUser.Id },
                new OrderType{ Id = 11, OperationCategory = Category.EXPENDITURE, Name = "Healthcare", UserId = SystemUser.Id },
                new OrderType{ Id = 12, OperationCategory = Category.EXPENDITURE, Name = "Investing", UserId = SystemUser.Id }
            });

            //base.OnModelCreating(modelBuilder);
        }
    }
}
