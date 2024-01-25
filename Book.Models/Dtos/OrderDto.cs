using Book.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Models.Dtos
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }
        public double Total { get; set; }
        public DateTime DateTime { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string UserFullName { get; set; }
        public string UserAddress { get; set; }


    }
}
