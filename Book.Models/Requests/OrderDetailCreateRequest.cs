using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Models.Requests
{
    public class OrderDetailCreateRequest
    {
        public int Quantity { get; set; }
        public int Price { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
    }
}
