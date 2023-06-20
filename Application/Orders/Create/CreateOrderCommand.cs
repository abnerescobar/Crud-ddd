using Application.Orders.Common;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Create;

public record CreateOrderCommand(Guid CustomerId, List<CreateLineItemCommand> Items) : IRequest<ErrorOr<OrderResponse>>;

public record CreateLineItemCommand(
    Guid ProductId, 
    decimal Quantity,
    decimal Price);
