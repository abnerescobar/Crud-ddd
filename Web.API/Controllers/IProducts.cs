using Application.Orders.Create;
using Application.Products;
using Application.Products.Create;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    public interface IProducts
    {
        Task<IActionResult> Create([FromBody] CreateOrderCommand command);
        Task<IActionResult> Create([FromBody] CreateProductCommand command);
    }
}