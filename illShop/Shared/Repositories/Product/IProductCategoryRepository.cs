using AutoMapper;
using illShop.Shared.BasicObjects.Paging;
using illShop.Shared.BasicServices;
using illShop.Shared.Dto.DtosRelatedProduct;
using KernelLogic.DataBaseObjects;
using Microsoft.EntityFrameworkCore;


namespace illShop.Shared.Repositories.Product
{
    public interface IProductCategoryRepository
    {
        Task<int> AddProductCategoryAsync(ProductCategoryDto productCategoryDto);
        Task<List<ProductCategoryDto>> GetAllProductCategoryAsync();
        Task<PagedList<ProductCategoryDto>> GetPagedProductCategories(PagingParameters pagingParameters);
        Task UpdateProductCategory(ProductCategoryDto productCategoryDto);
        Task DeleteProductCategory(int id);
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

        public async Task<PagedList<ProductCategoryDto>> GetPagedProductCategories(PagingParameters pagingParameters)
        {
            var productCategoryList = await _productCategory.Search(pagingParameters.SearchTerm).Sort(pagingParameters.OrderBy).ToListAsync();
            var productCategoryDtoList = _mapper.Map<List<ProductCategoryDto>>(productCategoryList);
            return PagedList<ProductCategoryDto>.ToPagedList(productCategoryDtoList, pagingParameters.PageNumber, pagingParameters.PageSize);
        }

        public async Task UpdateProductCategory(ProductCategoryDto productCategoryDto)
        {
            var data = _mapper.Map<KernelLogic.DataBaseObjects.Entities.ProductCategory>(productCategoryDto);
            _productCategory.Update(data);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteProductCategory(int id)
        {
            _productCategory.Remove(await _productCategory.FirstOrDefaultAsync(p => p.Id.Equals(id)));
            await _dataContext.SaveChangesAsync();
        }
    }
}