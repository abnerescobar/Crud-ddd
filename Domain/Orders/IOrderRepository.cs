using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders;

public interface IOrderRepository
{
    Task<Order?> GetByIdWithLineItemAsync(OrderId id, LineItemId lineItemId);
    bool HasOneLineItem(Order order);
    void Add(Order order);
}
