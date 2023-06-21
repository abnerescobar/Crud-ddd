using Domain.Primitives;
using Domain.Products;
using Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products;

internal class CreateProductCommandHandler: IRequestHandler<CreateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateProductCommandHandler(
        IProductRepository repository,
        IUnitOfWork unitOfWork)
    {
        _productRepository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(
            new ProductId(Guid.NewGuid()),
            Sku.Create(request.Sku)!,
            request.Name,
            new Money(request.Currency, request.Amunt));
        _productRepository.Add(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
