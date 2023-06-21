using Application.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[Route("products")]
public class Products : ApiController
{
    private readonly ISender _mediator;

    public Products(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
    {
        var createProductResult = await _mediator.Send(command);

        return createProductResult.Match(
            Order => Ok(createProductResult.value),
            ErrorsControler => Problem(errors)
            
            );

    }
    
}
