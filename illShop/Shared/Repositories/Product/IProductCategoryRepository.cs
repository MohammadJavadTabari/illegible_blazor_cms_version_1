using AutoMapper;
using illShop.Shared.Dto.DtosRelatedProduct;
using KernelLogic.DataBaseObjects;
using Microsoft.EntityFrameworkCore;


namespace illShop.Shared.Repositories.Product
{
    public interface IProductCategoryRepository
    {
        Task<int> AddProductCategoryAsync(ProductCategoryDto productCategoryDto);
        Task<List<ProductCategoryDto>> GetAllProductCategoryAsync();
    }
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private DataContext _dataContext;
        private DbSet<KernelLogic.DataBaseObjects.Entities.ProductCategory> _productCategory;
        private readonly IMapper _mapper;

        public ProductCategoryRepository(DataContext dataContext, IMapper mapper) : base()
        {
            _dataContext = dataContext;
            _productCategory = _dataContext.Set<KernelLogic.DataBaseObjects.Entities.ProductCategory>();
            _mapper = mapper;
        }
        public async Task<int> AddProductCategoryAsync(ProductCategoryDto productCategoryDto)
        {
            var entity = _mapper.Map<KernelLogic.DataBaseObjects.Entities.ProductCategory>(productCategoryDto);
            await _productCategory.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<List<ProductCategoryDto>> GetAllProductCategoryAsync()
        {
            return _mapper.Map<List<ProductCategoryDto>>(await _productCategory.ToListAsync());
        }
    }
}