using System.ComponentModel.DataAnnotations;

namespace illShop.Shared.Dto.DtosRelatedProduct
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="please fill product name field")]
        public string ProductName { get; set; } = "productName";
        [Required(ErrorMessage = "please fill price field"), Range(1, long.MaxValue, ErrorMessage = "price should be greater than or equal '1'")]
        public long Price { get; set; } = 1;
        [Required]
        public string ImageUrl { get; set; } = "ImageUrl";
        public string Desceription { get; set; } = "There is'nt any desceription for this product";
        public string Supplier { get; set; } = "illShop";
        public DateTime ManufactureDate { get; set; }
        public List<ProductReviewDto>? ProductReviews { get; set; }
        public int ProductCategoryId { get; set; }
        public ProductCategoryDto? ProductCategory { get; set; }
    }
}
