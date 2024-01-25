using Book.Api.Entities;
using Book.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book.Api.Entities
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public double Total { get; set; }
        public DateTime DateTime { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Guid? UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
