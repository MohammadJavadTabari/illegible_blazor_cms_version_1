using System.ComponentModel.DataAnnotations;

namespace illShop.Shared.Dto.DtosRelatedProduct
{
    public class ProductDto
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage ="please fill product name field")]
        public string ProductName { get; set; } = "productName";
        [Required(ErrorMessage = "please fill price field"), Range(1, long.MaxValue, ErrorMessage = "price should be greater than or equal '1'")]
        public long Price { get; set; } = 1;
        [Required]
        public string ImageUrl { get; set; } = "ImageUrl";
    }
}
