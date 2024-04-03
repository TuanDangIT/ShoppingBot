using ShoppingBot.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Entities
{
    public class Order : IAuditable
    {
        public Guid Id { get; set; }
        public string Buyer { get; set; } = default!;
        public Product Product { get; set; } = default!;
        public Guid ProductId { get; set; } 
        public string ServerId { get; set; } = default!;
        public DateTime CreatedAt { get; }
        public DateTime LastUpdatedAt { get; }
    }
}
