﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public double Price { get; set; }
        public string Description { get; set; } = default!;
        public string? ImageUrl { get; set; }
        public string ServerId { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set;}
    }
}
