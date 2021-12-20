using illShop.Shared.Dto.DtosRelatedProduct;
using KernelLogic.DataBaseObjects;
using Microsoft.EntityFrameworkCore;

namespace illShop.Shared.Repositories.Product
{
    public interface IProductRepository
    {
        Task<int> AddProductAsync(ProductDto productDto);
    }

    public class ProductRepository : IProductRepository
    {
        private DataContext _dataContext;
        private DbSet<KernelLogic.DataBaseObjects.Entities.Product> _products;

        public ProductRepository(DataContext dataContext) : base()
        {
            _dataContext = dataContext;
            _products = _dataContext.Set<KernelLogic.DataBaseObjects.Entities.Product>();
        }

        public async Task<int> AddProductAsync(ProductDto productDto)
        {
            var entity = new KernelLogic.DataBaseObjects.Entities.Product() { 
            ImageUrl =" sdfds",
            Price = 123,
            ProductId = 0,
            ProductName = "test"
            };
            await _products.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return entity.ProductId;
        }
    }
}
