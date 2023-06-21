using Microsoft.AspNetCore.Mvc;
using Application.Orders.Create;
using Application.Products.Create;
namespace Web.API.Controllers
{
    public interface IProducts
    {
        Task<IActionResult> Create([FromBody] CreateOrderCommand command);
        Task<IActionResult> Create([FromBody] CreateProductCommand command);
    }
}