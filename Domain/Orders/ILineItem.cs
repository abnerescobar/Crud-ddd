using Domain.Products;
using Domain.ValueObjects;

namespace Domain.Orders
{
    public interface ILineItem
    {
        LineItemId LineItemId { get; }
        OrderId OrderId { get; }
        Money Price { get; }
        ProductId ProductId { get; }
        decimal Quantity { get; }
    }
}