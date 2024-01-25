using Book.Api.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book.Api.Entities
{
    public class OrderDetail
    {
        [Key]
        public Guid OrderDetailId { get; set; }
        public  int Quantity { get; set; }
        public  int Price { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public Guid OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

    }
}
