using System.ComponentModel.DataAnnotations;

namespace illShop.Shared.Dto.DtosRelatedProduct
{
    public class ProductReviewDto
    {
        [Key]
        public int ProductReviewId { get; set; }
        public string UserName { get; set; } = "User Of IllShop";
        public string? UserComment { get; set; }
        [Required]
        [Range(0, 5)]
        public int Rate { get; set; }
        //public ProductDto Product { get; set; } = new();
    }
}
