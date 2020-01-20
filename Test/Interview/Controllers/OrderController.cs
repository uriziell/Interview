using System;
using System.Web.Http;
using Interview.Data.Contracts;
using Interview.Data.Repositories;
using Interview.Domain.Constants;
using Interview.Domain.Models;

namespace Interview.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController()
        {
            _orderRepository = new OrderRepository();
        }


        public IHttpActionResult Get()
        {
            var orders = _orderRepository.Get();
            if (orders == null)
                return NotFound();
            return Ok(orders);
        }

        [HttpGet]
        [Authorize(Roles = Roles.User)]
        public IHttpActionResult Get(Guid id)
        {
            var order = _orderRepository.Get(id);
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        [HttpPost]
        [Authorize(Roles = Roles.User)]
        public IHttpActionResult Post(Order newOrder)
        {
            var order = _orderRepository.Create(newOrder);
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        [HttpPut]
        [Authorize(Roles = Roles.User)]
        public IHttpActionResult Put(Order order)
        {
            var updatedOrder = _orderRepository.Update(order);
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        [HttpDelete]
        [Authorize(Roles = Roles.User)]
        public IHttpActionResult Delete(Guid id)
        {
            _orderRepository.Remove(id);
            return Ok();
        }
    }
}
