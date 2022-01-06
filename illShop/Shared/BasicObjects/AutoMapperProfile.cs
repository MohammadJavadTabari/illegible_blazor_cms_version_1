using AutoMapper;
using illShop.Shared.Dto.DtosRelatedBlog;
using illShop.Shared.Dto.DtosRelatedIdentity;
using illShop.Shared.Dto.DtosRelatedProduct;
using KernelLogic.DataBaseObjects.Entities;
using Microsoft.AspNetCore.Identity;

namespace illShop.Shared.BasicObjects
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductReview, ProductReviewDto>().ReverseMap();
            CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();
            CreateMap<IdentityUser, UserDetailDto>().ReverseMap();
            CreateMap<BlogPost, BlogPostDto>().ReverseMap();
        }
    }
}
