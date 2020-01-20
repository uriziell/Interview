using System;
using System.Linq;
using Interview.Data.Contracts;
using Interview.Data.Repositories;
using Interview.Domain.Models;
using NUnit.Framework;

namespace Interview.Tests.Controllers
{
    [TestFixture]
    public class OrderRepositoryTests
    {
        private IOrderRepository _orderRepository;

        [SetUp]
        public void Setup()
        {
            _orderRepository = new OrderRepository();
        }

        [Test]
        public void Get_should_return_all_orders()
        {
            // Arrange

            // Act
            var result = _orderRepository.Get();

            // Assert
            Assert.IsNotNull(result);
        }

        public void Get_should_return_object_with_id()
        {
            // Arrange
            var id = new Guid("3f2b12b8-2a06-45b4-b057-45949279b4e5");
            // Act
            var result = _orderRepository.Get(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
        }

        [Test]
        public void Create_Should_Add_and_return_new_created_object()
        {
            // Arrange
            var ordersCount = _orderRepository.Get().ToList().Count;
            var order = new Order
            {
                Id = Guid.NewGuid(),
                Amount = 1000,
                ApplicationId = 11111,
                IsCleared = true,
                ClearedDate = new DateTime(),
                PostingDate = new DateTime(),
                Summary = "test",
                Type = "TestType"
            };
            // Act
            var result = _orderRepository.Create(order);
            var currentOrdersCount = _orderRepository.Get().ToList().Count;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(order.Id, result.Id);
            Assert.AreEqual(order.Amount, result.Amount);
            Assert.AreEqual(order.ApplicationId, result.ApplicationId);
            Assert.AreEqual(order.IsCleared, result.IsCleared);
            Assert.AreEqual(order.PostingDate, result.PostingDate);
            Assert.AreEqual(order.Summary, result.Summary);
            Assert.AreEqual(order.Type, result.Type);
            Assert.AreEqual(ordersCount + 1, currentOrdersCount);
        }

        [Test]
        public void Update_should_update_and_return_order()
        {
            // Arrange
            var order = new Order()
            {
                Id = Guid.NewGuid(),
                Amount = 1000,
                ApplicationId = 11111,
                IsCleared = true,
                Summary = "test",
                Type = "TestType"
            };
            _orderRepository.Create(order);
            var ordersCount = _orderRepository.Get().ToList().Count;

            var updatedOrder = new Order()
            {
                Id = order.Id,
                Amount = 1500,
                ApplicationId = 1000,
                IsCleared = true,
                Summary = "test",
                Type = "TestType"
            };

            // Act
            var result = _orderRepository.Update(updatedOrder);
            var currentOrdersCount = _orderRepository.Get().ToList().Count;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(order.Id, result.Id);
            Assert.AreEqual(updatedOrder.Amount, result.Amount);
            Assert.AreEqual(updatedOrder.ApplicationId, result.ApplicationId);
            Assert.AreEqual(updatedOrder.Summary, result.Summary);
            Assert.AreEqual(updatedOrder.Type, result.Type);
            Assert.AreEqual(ordersCount, currentOrdersCount);
        }

        [Test]
        public void Remove_should_remove_order()
        {
            // Arrange
            var order = new Order()
            {
                Id = Guid.NewGuid(),
                Amount = 1000,
                ApplicationId = 11111,
                IsCleared = true,
                Summary = "Test",
                Type = "TestType"
            };
            _orderRepository.Create(order);
            var ordersCount = _orderRepository.Get().ToList().Count;

            // Act
            _orderRepository.Remove(order.Id);
            var currentOrdersCount = _orderRepository.Get().ToList().Count;

            // Assert
            Assert.IsNull(_orderRepository.Get(order.Id));
            Assert.AreEqual(ordersCount - 1, currentOrdersCount);
        }
    }
}