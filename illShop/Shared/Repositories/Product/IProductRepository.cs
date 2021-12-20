using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProductRepository(DataContext dataContext, IMapper mapper) : base()
        {
            _dataContext = dataContext;
            _products = _dataContext.Set<KernelLogic.DataBaseObjects.Entities.Product>();
            _mapper = mapper;
        }

        public async Task<int> AddProductAsync(ProductDto productDto)
        {
            var entity = _mapper.Map<ProductDto,KernelLogic.DataBaseObjects.Entities.Product>(productDto);
            await _products.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return entity.ProductId;
        }
    }
}
