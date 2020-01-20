using System;

namespace Interview.Domain.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public int ApplicationId { get; set; }
        public string Type { get; set; }
        public string Summary { get; set; }
        public double Amount { get; set; }
        public DateTime? PostingDate { get; set; }
        public bool IsCleared { get; set; }
        public DateTime? ClearedDate { get; set; }
    }
}

