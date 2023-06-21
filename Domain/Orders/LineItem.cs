using Domain.Products;
using Domain.ValueObjects;


namespace Domain.Orders;

public sealed class LineItem
{
    public LineItem(LineItemId id, OrderId orderId, ProductId productId, decimal quantity, Money price)
    {
        Id = id;
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }

    private LineItem() 
    {
        
    }
   public LineItemId Id { get; private set; }
   public OrderId OrderId { get; private set; } 
   public ProductId ProductId { get; private set; }
   public decimal Quantity { get; private set; }
   public Money Price { get; private set; }
}
