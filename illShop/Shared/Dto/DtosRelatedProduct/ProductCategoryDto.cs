namespace illShop.Shared.Dto.DtosRelatedProduct
{
    public class ProductCategoryDto
    {
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public List<ProductDto>? Products { get; set; }
    }
}
