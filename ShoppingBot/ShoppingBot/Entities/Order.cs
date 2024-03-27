using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public string ServerId { get; set; } = default!;
    }
}
