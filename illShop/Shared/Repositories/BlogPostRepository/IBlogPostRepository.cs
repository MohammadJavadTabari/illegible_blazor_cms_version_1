using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using illShop.Shared.BasicObjects.Paging;
using illShop.Shared.BasicServices;
using KernelLogic.DataBaseObjects;
using KernelLogic.DataBaseObjects.Entities;
using Microsoft.EntityFrameworkCore;

namespace illShop.Shared.Repositories.BlogPostRepository
{
    public interface IBlogPostRepository
    {
        Task<long> AddBlogPostAsync(BlogPost entity);
        Task<BlogPost> GetBlogPostByIdAsync(long id);
        Task<List<BlogPost>> GetAllBlogPostAsync();
        //pagination
        Task<PagedList<BlogPost>> GetPagingPost(PagingParameters pagingParameters);
    }
    public class BlogPostRepository : IBlogPostRepository
    {
        private DataContext _dataContext;
        private DbSet<BlogPost> _blogPost;

        public BlogPostRepository(DataContext dataContext) : base()
        {
            _dataContext = dataContext;
            _blogPost = _dataContext.Set<BlogPost>();
        }

        public async Task<long> AddBlogPostAsync(BlogPost entity)
        {
            await _blogPost.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return entity.Id;
        }

        public Task<List<BlogPost>> GetAllBlogPostAsync()
        {
            return _blogPost.ToListAsync();
        }

        public Task<BlogPost> GetBlogPostByIdAsync(long id)
        {
            return _blogPost.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<PagedList<BlogPost>> GetPagingPost(PagingParameters pagingParameters)
        {
            var posts = await _blogPost.Search(pagingParameters.SearchTerm).Sort(pagingParameters.OrderBy).ToListAsync();
            return PagedList<BlogPost>.ToPagedList(posts, pagingParameters.PageNumber, pagingParameters.PageSize);
        }
    }
  
    
}
