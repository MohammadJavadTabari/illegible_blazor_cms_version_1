using System.ComponentModel.DataAnnotations;

namespace illShop.Shared.Dto.DtosRelatedProduct
{
    public class ProductReviewDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = "User Of IllShop";
        public string? UserComment { get; set; }
        [Required]
        [Range(0, 5)]
        public int Rate { get; set; }
        public int ProductId { get; set; }
        //public Product Product { get; set; }
    }
}
