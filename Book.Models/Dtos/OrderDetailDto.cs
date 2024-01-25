using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Models.Dtos
{
    public class OrderDetailDto
    {
        public Guid OrderDetailId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string ProductName { get; set; }
        public string FullName { get; set; }
    }
}
