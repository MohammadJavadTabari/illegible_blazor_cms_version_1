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
        Task<PagedList<ProductDto>> GetPagedProducts(PagingParameters pagingParameters);
        Task<List<ProductDto>> GetProducts();
        List<ProductDto> GetLatestProducts();
        Task<ProductDto> GetProduct(int id);
        Task UpdateProduct(ProductDto productDto);
        Task DeleteProduct(int id);
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
            var entity = _mapper.Map<ProductDto, KernelLogic.DataBaseObjects.Entities.Product>(productDto);
            await _products.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<PagedList<ProductDto>> GetPagedProducts(PagingParameters pagingParameters)
        {
            var products = await _products.Include(x=>x.ProductReviews).Search(pagingParameters.SearchTerm).Sort(pagingParameters.OrderBy).ToListAsync();
            var productDtoList = _mapper.Map<List<ProductDto>>(products);
            return PagedList<ProductDto>.ToPagedList(productDtoList, pagingParameters.PageNumber, pagingParameters.PageSize);
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            return _mapper.Map<ProductDto>(await _products.Include(x => x.ProductReviews).FirstOrDefaultAsync(p => p.Id.Equals(id)));
        }

        public async Task UpdateProduct(ProductDto productDto)
        {
            var data = _mapper.Map<KernelLogic.DataBaseObjects.Entities.Product>(productDto);
            _products.Update(data);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            _products.Remove(await _products.FirstOrDefaultAsync(p => p.Id.Equals(id)));
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            var products = await _products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }

        public List<ProductDto> GetLatestProducts()
        {
            var latestProducts = _products.ToList().OrderByDescending(u => u.ProductName.Count()).Take(10).ToList();
           return _mapper.Map<List<ProductDto>>(latestProducts);
        }
    }
}