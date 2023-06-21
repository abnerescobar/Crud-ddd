using Application.Orders.Common;
using ErrorOr;
using MediatR;
namespace Application.Orders.Create;

public record CreateOrderCommand(Guid CustomerId, List<CreateLineItemCommand> Items) : IRequest<ErrorOr<OrderResponse>>;

public record CreateLineItemCommand(
    Guid ProductId, 
    decimal Quantity,
    decimal Price);
