using AutoMapper;
using illShop.Shared.BasicObjects.Paging;
using illShop.Shared.BasicServices;
using illShop.Shared.Dto.DtosRelatedProduct;
using KernelLogic.DataBaseObjects;
using Microsoft.EntityFrameworkCore;

namespace illShop.Shared.Repositories.Product
{
    public interface IProductRepository
    {
        Task<int> AddProductAsync(ProductDto productDto);
        Task<PagedList<ProductDto>> GetPagedBlogPosts(PagingParameters pagingParameters);
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

        public async Task<PagedList<ProductDto>> GetPagedBlogPosts(PagingParameters pagingParameters)
        {
            var products = await _products.Search(pagingParameters.SearchTerm).Sort(pagingParameters.OrderBy).ToListAsync();
            var productDtoList = _mapper.Map<List<ProductDto>>(products);
            return PagedList<ProductDto>.ToPagedList(productDtoList, pagingParameters.PageNumber, pagingParameters.PageSize);
        }
    }
}