﻿using AutoMapper;
using illShop.Shared.BasicObjects.Paging;
using illShop.Shared.BasicServices;
using illShop.Shared.Dto.DtosRelatedBlog;
using KernelLogic.DataBaseObjects;
using KernelLogic.DataBaseObjects.Entities;
using Microsoft.EntityFrameworkCore;

namespace illShop.Shared.Repositories.BlogPostRepository
{
    public interface IBlogPostRepository
    {
        Task<long> AddBlogPostAsync(BlogPostDto dto);
        Task<BlogPost> GetBlogPostByIdAsync(long id);
        Task<List<BlogPost>> GetAllBlogPostAsync();
        Task DeleteBlogPostAsync(int id);
        //pagination
        Task<PagedList<BlogPost>> GetPagingPost(PagingParameters pagingParameters);
    }
   
    public class BlogPostRepository : IBlogPostRepository
    {
        private DataContext _dataContext;
        private DbSet<BlogPost> _blogPost;
        private readonly IMapper _mapper;

        public BlogPostRepository(DataContext dataContext,IMapper mapper) : base()
        {
            _dataContext = dataContext;
            _blogPost = _dataContext.Set<BlogPost>();
            _mapper = mapper;
        }

        public async Task<long> AddBlogPostAsync(BlogPostDto dto)
        {
            var entity = _mapper.Map<BlogPost>(dto);
            await _blogPost.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return entity.Id;
        }

        public Task<List<BlogPost>> GetAllBlogPostAsync()
        {
            return _blogPost.ToListAsync();
        }

        public async Task<BlogPost> GetBlogPostByIdAsync(long id) => await _blogPost.FirstOrDefaultAsync(b => b.Id == id);

        public async Task<PagedList<BlogPost>> GetPagingPost(PagingParameters pagingParameters)
        {
            var posts = await _blogPost.Search(pagingParameters.SearchTerm).Sort(pagingParameters.OrderBy).ToListAsync();
            return PagedList<BlogPost>.ToPagedList(posts, pagingParameters.PageNumber, pagingParameters.PageSize);
        }

        public async Task DeleteBlogPostAsync(int id)
        {
            _blogPost.Remove(await _blogPost.FirstOrDefaultAsync(p => p.Id.Equals(id)));
            await _dataContext.SaveChangesAsync();
        }
    }
  
}
