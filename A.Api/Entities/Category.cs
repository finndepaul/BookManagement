using Book.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Book.Api.Entities
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Status Status { get; set; }
        public List<Product> Products { get; set; }
    }
}
