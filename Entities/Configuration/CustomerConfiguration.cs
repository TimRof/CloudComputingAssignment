using Entities.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData
            (
                new Customer
                {
                    Name = "Test Name 1",
                    Email = "test1@example.com",
                    MonthlyIncome = 1000
                },
                new Customer
                {
                    Name = "Test Name 2",
                    Email = "test2@example.com",
                    MonthlyIncome = 2000
                },
                new Customer
                {
                    Name = "Test Name 3",
                    Email = "test3@example.com",
                    MonthlyIncome = 3000
                }
            );
        }
    }
}
