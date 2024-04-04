using ShoppingBot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.DTOs
{
    internal class OrderDto
    {
        public Guid Id { get; set; }
        public string Buyer { get; set; } = default!;
        public Product Product { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
}
