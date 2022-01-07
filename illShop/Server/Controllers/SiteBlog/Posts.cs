using AutoMapper;
using illShop.Shared.BasicObjects.Paging;
using illShop.Shared.Dto.DtosRelatedBlog;
using illShop.Shared.Repositories.BlogPostRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace illShop.Server.Controllers.SiteBlog
{
    [Route("blogPostHandler")]
    [ApiController]
    public class Posts : ControllerBase
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public Posts(IBlogPostRepository blogPostRepository, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _blogPostRepository = blogPostRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("AddBlogPost")]
        public async Task<IActionResult> AddBlogPost([FromBody] BlogPostDto blogPostDto)
        {
            blogPostDto.Author = "Illegible";//_userManager.GetUserName(User);
            var blogPost =await _blogPostRepository.AddBlogPostAsync(blogPostDto);
            return Created("", blogPost);
        }

        [HttpGet]
        [Route("GetAllBlogPost")]
        public async Task<IEnumerable<BlogPostDto>> GetAllBlogPost()
        {
            var blogPostList = await _blogPostRepository.GetAllBlogPostAsync();
            var blogPostDtoList = _mapper.Map<IEnumerable<BlogPostDto>>(blogPostList);
            return blogPostDtoList;
        }

        [HttpGet]
        [Route("GetBlogPost/{postId}")]
        public async Task<BlogPostDto> GetBlogPostById([FromRoute] int postId)
        {
            return await _blogPostRepository.GetBlogPostByIdAsync(postId);
        }
        [HttpDelete]
        [Route("DeleteBlogPost/{postId}")]
        public async Task<IActionResult> DeleteBlogPostById([FromRoute] int postId)
        {
            await _blogPostRepository.DeleteBlogPostAsync(postId);
            return NoContent();
        }
        [HttpGet]
        [Route("GetPagedBlogPosts")]
        public async Task<IActionResult> GetPagedBlogPosts([FromQuery] PagingParameters pagingParameters)
        {
            var products = await _blogPostRepository.GetPagingPost(pagingParameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(products.MetaData));
            return Ok(products);
        }
        [HttpPut]
        [Route("UpdateBlogPost")]
        public async Task<IActionResult> EditBlogPost([FromBody] BlogPostDto blogPostDto)
        {
            await _blogPostRepository.UpdateBlogPostAsync(blogPostDto);
            return NoContent();
        }
    }
}
