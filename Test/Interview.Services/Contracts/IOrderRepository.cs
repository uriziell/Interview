using System;
using System.Collections.Generic;
using Interview.Domain.Models;

namespace Interview.Data.Contracts
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Get();
        Order Get(Guid id);
        Order Create(Order order);
        Order Update(Order order);
        void Remove(Guid id);
    }
}