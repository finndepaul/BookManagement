using Book.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Models.Dtos
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public double? SalePrice { get; set; }
        public Status status { get; set; }
        public string CategoryName { get; set; }  
    }
}
