using Book.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Models.Requests
{
    public class ProductCreateRequest
    {
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public double? SalePrice { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
