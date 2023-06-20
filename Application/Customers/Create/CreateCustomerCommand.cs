using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Create
{
    public record CreateCustomerCommand(
        string Name,
        string LastName,
        string Email,
        string PhoneNumber,
        string Country,
        string Line1,
        string Line2,
        string City,
        string State,
        string ZipCode) : IRequest<ErrorOr<Unit>>
    {
    }
}
