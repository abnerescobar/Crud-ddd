using Domain.Primitives;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products;

public sealed class Product : AggregateRoot
{
    public Product(ProductId id, Sku sku, string name, Money price)
    {
        Id = id;
        Sku = sku;
        Name = name;
        Price = price;
    }
    private Product(ProductId productId)
    {

    }
    public ProductId Id { get; private set; }
    public Sku Sku { get; private set; } 
    public string Name { get; private set; } = string.Empty;
    public Money Price { get; private set; }
}
