using illShop.Shared.Dto.DtosRelatedProduct;

namespace illShop.Client.Pages.AdminComponents
{
    public partial class ProductCategory
    {
        public ProductCategoryDto ProductCategoryDto = new();
        public string Icon { get; set; } = "fas fa-basketball-ball";
        private async Task Create()
        {
            ProductCategoryDto.Icon = Icon;
            await _httpRequestHandler.PostAsHttpJsonAsync(ProductCategoryDto, "CategoryHandler/AddProductCategory");
            _snackbar.Add("Product Category Added Successfully",MudBlazor.Severity.Success);
        }
        List<string> iconsList = new List<string>()
        {
            "fas fa-basketball-ball",
            "fas fa-bicycle",
            "fas fa-beer",
            "fas fa-blender-phone",
            "fab fa-btc",
            "fas fa-business-time",
            "fas fa-cart-arrow-down",
            "fas fa-carrot",
            "fas fa-cocktail",
            "fab fa-android",
            "fas fa-capsules",
            "fas fa-car",
            "fas fa-bed",
            "fas fa-chalkboard",
            "fas fa-couch",
            "fas fa-tshirt",
            "fas fa-user-tie",
            "fas fa-mitten",
            "fas fa-shoe-prints",
            "fas fa-hat-cowboy"
        };
    }
}