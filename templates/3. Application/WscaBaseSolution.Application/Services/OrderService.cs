using WscaBaseSolution.Domain.Entities;
using WscaBaseSolution.Domain.Interfaces;
using CSharpFunctionalExtensions;

namespace WscaBaseSolution.Application.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<IEnumerable<Order>>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return Result.Success(orders);
        }

        public async Task<Result<Order>> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order == null)
            {
                return Result.Failure<Order>("Order not found");
            }
            return Result.Success(order);
        }

        public async Task<Result> CreateOrderAsync(string customer)
        {
            var orderResult = Order.Create(customer);
            if (orderResult.IsFailure)
            {
                return Result.Failure(orderResult.Error);
            }

            var order = orderResult.Value;
            await _orderRepository.AddOrderAsync(order);
            return Result.Success();
        }

        public async Task<Result> AddOrderItemAsync(int orderId, int productId, string productName, decimal unitPrice, int quantity)
        {
            var orderResult = await GetOrderByIdAsync(orderId);
            if (orderResult.IsFailure)
            {
                return orderResult;
            }

            var order = orderResult.Value;
            var addItemResult = order.AddItem(productId, productName, unitPrice, quantity);
            if (addItemResult.IsFailure)
            {
                return addItemResult;
            }

            await _orderRepository.UpdateOrderAsync(order);
            return Result.Success();
        }
    }
}
