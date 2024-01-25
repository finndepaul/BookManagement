using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Models.Requests
{
    public class OrderDetailUpdateRequest
    {
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
