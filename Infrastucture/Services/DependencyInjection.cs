using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Infrastucture.Persistence;
using Application.Data;
using MySql.EntityFrameworkCore;
using Domain.Primitives;
using Infrastucture.Persistence.Repositories;
using Domain.Customers;
using Domain.Orders;
using Domain.Products;

namespace Infrastucture;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);
        return services;
    }
    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options=> options.UseMySQL(configuration.GetConnectionString("MySQL")));
        services.AddScoped<IApplicationDbContext>(sp=> sp.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IcustomerRepository, CustomerRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
}