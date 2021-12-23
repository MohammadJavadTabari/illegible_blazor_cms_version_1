using System.ComponentModel.DataAnnotations;

namespace KernelLogic.DataBaseObjects.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [Required]
        [Range(1,long.MaxValue)]
        public long Price { get; set; }
        [Required]
        public string? ImageUrl { get; set; }
        public string Desceription { get; set; } = "There is'nt any desceription for this product";
        public string Supplier { get; set; } = "illShop";
        public List<ProductReview>? ProductReviews { get; set; }
    }
}
