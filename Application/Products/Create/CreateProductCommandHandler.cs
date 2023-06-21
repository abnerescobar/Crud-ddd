using Application.Products.Common;
using Domain.Primitives;
using Domain.Products;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;
namespace Application.Products.Create;

internal class CreateProductCommandHandler: IRequestHandler<CreateProductCommand, ErrorOr<ProductResponse>>
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

    public async Task<ErrorOr<ProductResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(
            new ProductId(Guid.NewGuid()),
            Sku.Create(request.Sku)!,
            request.Name,
            new Money(request.Currency, request.Amount));
        _productRepository.Add(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return new ProductResponse();
    }
}
