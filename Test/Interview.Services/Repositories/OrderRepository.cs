using System;
using System.Collections.Generic;
using System.Linq;
using Interview.Data.Contracts;
using Interview.Domain.Models;
using Interview.Infrastructure.Contracts;
using Interview.Infrastructure.Services;

namespace Interview.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IJsonOperationService _jsonOperationService;
        public OrderRepository()
        {
            _jsonOperationService = new JsonOperationService();
        }
        public IEnumerable<Order> Get()
        {
            return GetAll<Order>();
        }

        public Order Get(Guid id)
        {
            return GetAll<Order>().FirstOrDefault(x => x.Id == id);
        }

        public Order Create(Order order)
        {
            var orders = GetAll<Order>().ToList();
            orders.Add(order);

            _jsonOperationService.UpdateJsonFile(orders);

            return order;
        }

        public Order Update(Order order)
        {
            var orders = GetAll<Order>().ToList();
            var orderToRemove = orders.FirstOrDefault(x => x.Id == order.Id);

            if (orderToRemove == null) return null;

            order.Id = orderToRemove.Id;
            orders.Remove(orderToRemove);
            orders.Add(order);

            _jsonOperationService.UpdateJsonFile(orders);

            return order;
        }

        public void Remove(Guid id)
        {
            var orders = GetAll<Order>().ToList();
            var order = orders.FirstOrDefault(x => x.Id == id);

            if (order == null)
                return;

            orders.Remove(order);
            _jsonOperationService.UpdateJsonFile(orders);
        }

        private IEnumerable<T> GetAll<T>()
        {
            return _jsonOperationService.LoadJsonFile<T>();
        }
    }
}