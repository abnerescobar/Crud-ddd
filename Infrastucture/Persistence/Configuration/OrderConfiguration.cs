using Domain.Customers;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Persistence.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            builder.ToTable("Orders");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasConversion(
                OrderId => OrderId.Value,
                value => new OrderId(value));
            builder.HasOne<Customer>()
                    .WithMany()
                    .HasForeignKey(o => o.CustomerId)
                    .IsRequired();
            builder.HasMany(o => o.LineItems)
                    .WithOne()
                    .HasForeignKey(li => li.OrderId);

        }
    }
}
