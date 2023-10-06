using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElitaShop.Domain.Entities.Enums
{
    public enum OrderStatus
    {
        Checkout,
        Paid,
        Failed,
        Shipped,
        Delivered,
        Returned,
        Complete
    }
}
