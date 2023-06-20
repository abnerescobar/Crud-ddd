using Application.Orders.Common;
using Domain.Customers;
using Domain.Orders;
using Domain.Primitives;
using Domain.Products;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Create;

public sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ErrorOr<OrderResponse>>
{
    private readonly IcustomerRepository _customerRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateOrderCommandHandler(IcustomerRepository customerRepository, IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }

    
    public async Task<ErrorOr<OrderResponse>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(new CustomerId(request.CustomerId));
        if (customer is null)
        {
            return Error.NotFound("Customer.NotFound",$"Customer with the Id {request.CustomerId} no exists");
        }
        var order = Order.Create(customer.Id);
        if(!request.Items.Any())
        {
            return Error.NotFound("Order.Detail", "For create at order youneed to specify the items.");
        }
        foreach (var item in request.Items)
        {
            order.Add(new ProductId(item.ProductId), item.Quantity, new Money("$", item.Price));
        }
        _orderRepository.Add(order);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return new OrderResponse();
    }
}
