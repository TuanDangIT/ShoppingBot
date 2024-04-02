using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Entities.Interfaces
{
    internal interface IAuditable
    {
        DateTime CreatedAt { get; }
        DateTime LastUpdatedAt { get; }
    }
}
