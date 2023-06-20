
using Application.Orders.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Web.API.Controllers;

[Route("orders")]
public class Orders : ApiController
{
    private readonly ISender _mediator;

    public Orders(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
    {
        var createOrderResult = await _mediator.Send(command);

        return createOrderResult.Match(
            order => Ok(createOrderResult.Value),
            errors => Problem(errors)
        );
    }
}
