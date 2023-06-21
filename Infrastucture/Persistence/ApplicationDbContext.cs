using Application.Data;
using Domain.Customers;
using Domain.Orders;
using Domain.Primitives;
using Domain.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
{
    public readonly IPublisher _publisher;

    public ApplicationDbContext(DbContextOptions options, IPublisher publisher): base(options)
    {
        _publisher = publisher?? throw new ArgumentNullException(nameof(publisher));
    }

    public DbSet<Customer> Customers { get ; set ; }
    public DbSet<LineItem> LineItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
    public override async Task<int>SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken()) 
    {
        var domainEvents = ChangeTracker.Entries<AggregateRoot>()
            .Select(e => e.Entity)
            .Where(e => e.GetDomainEvents().Any())
            .SelectMany(e => e.GetDomainEvents());
        var result = await base.SaveChangesAsync(cancellationToken);
        foreach (var domainEvent in domainEvents) 
        {
            await _publisher.Publish(domainEvent, cancellationToken);
        }
        return result;
    }
}
