using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WscaBaseSolution.Application.Services;
using WscaBaseSolution.Domain.Entities;
using WscaBaseSolution.Domain.Interfaces;
using WscaBaseSolution.Infrastructure;
using WscaBaseSolution.Infrastructure.Data;
using WscaBaseSolution.Infrastructure.Interfaces;
using WscaBaseSolution.Infrastructure.Repositories;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("OrderDb")); // Using In-Memory DB for demo

        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.Services.AddScoped<OrderService>();

        builder.Services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<Program>();
            cfg.Lifetime = ServiceLifetime.Scoped;
        });

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins",
                builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            db.Database.EnsureCreated();
            AddWscaBaseSolutionData(db);
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // Use CORS policy
        app.UseCors("AllowAllOrigins");

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    private static void AddWscaBaseSolutionData(ApplicationDbContext context)
    {
        var order = Order.Create("John Doe").Value;
        order.AddItem(1, "Product A", 10.0m, 2);
        order.AddItem(2, "Product B", 20.0m, 1);

        context.Orders.Add(order);
        context.SaveChanges();
    }
}