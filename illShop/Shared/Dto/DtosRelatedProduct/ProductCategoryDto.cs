using System.ComponentModel.DataAnnotations;

namespace illShop.Shared.Dto.DtosRelatedProduct
{
    public class ProductCategoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="please fill categry name input")]
        public string? CategoryName { get; set; }
        public string? Icon { get; set; }
        public List<ProductDto>? Products { get; set; }
    }
}
