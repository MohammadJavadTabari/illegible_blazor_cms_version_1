using System.ComponentModel.DataAnnotations;

namespace KernelLogic.DataBaseObjects.Entities
{
    public class ProductReview
    {
        [Key]
        public int ProductReviewId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; } = "User Of IllShop";
        public string? UserComment { get; set; }
        [Required]
        [Range(0,5)]
        public int Rate { get; set; }
        public Product Product { get; set; } = new();
    }
}