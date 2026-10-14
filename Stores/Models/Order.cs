using System;
using System.Collections.Generic;

namespace Stores.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public UserModel User { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}