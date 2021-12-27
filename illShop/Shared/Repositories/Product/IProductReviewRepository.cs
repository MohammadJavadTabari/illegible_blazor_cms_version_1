using AutoMapper;
using illShop.Shared.BasicObjects.Paging;
using illShop.Shared.Dto.DtosRelatedProduct;
using KernelLogic.DataBaseObjects;
using KernelLogic.DataBaseObjects.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace illShop.Shared.Repositories.Product
{
    public interface IProductReviewRepository
    {
        Task<int> AddProductReviewAsync(ProductReviewDto productReviewDto);
        Task<PagedList<ProductReviewDto>> GetPagedProductReviews(PagingParameters pagingParameters);
        Task<ProductReviewDto> GetProductReview(int id);
        Task UpdateProductReview(ProductReviewDto productReviewDto);
        Task DeleteProductReview(int id);
    }
    public class ProductReviewRepository : IProductReviewRepository
    {
        private DataContext _dataContext;
        private DbSet<ProductReview> _productReviews;
        private readonly IMapper _mapper;

        public ProductReviewRepository(DataContext dataContext, IMapper mapper) : base()
        {
            _dataContext = dataContext;
            _productReviews = _dataContext.Set<ProductReview>();
            _mapper = mapper;
        }

        public async Task<int> AddProductReviewAsync(ProductReviewDto productReviewDto)
        {
            var entity = _mapper.Map<ProductReviewDto, ProductReview>(productReviewDto);
            await _productReviews.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return entity.Id;
        }
        public Task<PagedList<ProductReviewDto>> GetPagedProductReviews(PagingParameters pagingParameters)
        {
            throw new NotImplementedException();
        }

        public Task<ProductReviewDto> GetProductReview(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductReview(ProductReviewDto productDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductReview(int id)
        {
            throw new NotImplementedException();
        }
    }
}
