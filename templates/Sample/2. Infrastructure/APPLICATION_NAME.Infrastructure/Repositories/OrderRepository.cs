using APPLICATION_NAME.Domain.Entities;
using APPLICATION_NAME.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using APPLICATION_NAME.Infrastructure.Data;

namespace APPLICATION_NAME.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.Items)
                .ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await SaveChangesAsync(order);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            _context.Orders.Update(order);
            await SaveChangesAsync(order);
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await SaveChangesAsync(order);
            }
        }

        private async Task SaveChangesAsync(Order order)
        {
            await _context.SaveChangesAsync();
            await DispatchEvents(order);
        }

        private async Task DispatchEvents(Order order)
        {
            var events = order.DomainEvents;
            foreach (var domainEvent in events)
            {
                await _context.DomainEventDispatcher.Dispatch(domainEvent);
            }
            order.ClearDomainEvents();
        }
    }
}
