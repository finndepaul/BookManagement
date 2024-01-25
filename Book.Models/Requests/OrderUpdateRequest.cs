using Book.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Models.Requests
{
    public class OrderUpdateRequest
    {
        public double Total { get; set; }
        public DateTime DateTime { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
