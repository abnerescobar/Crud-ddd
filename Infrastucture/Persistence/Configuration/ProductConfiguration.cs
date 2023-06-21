using Domain.Orders;
using Domain.Products;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastucture.Persistence.Configuration;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {

        builder.HasKey(p => p.Id);

        builder.Property(li => li.Id).HasConversion(
            lineItemId => lineItemId.Value,
            value => new ProductId(value));

        builder.Property(p => p.Sku).HasConversion(
            sku => sku.Value,
            value => Sku.Create(value)!);

        builder.OwnsOne(p => p.Price, priceBuilder =>
        {
            priceBuilder.Property(m => m.Currency).HasMaxLength(3);

        });
    }

}
