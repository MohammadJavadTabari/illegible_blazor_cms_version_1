using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace illShop.Shared.Dto.DtosRelatedBlog
{
    public class BlogPostDto
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Author { get; set; }
        [Required]
        public string? Summary { get; set; }
        public DateTime WriteTime { get; set; }
        [Required]
        public string? PostContext { get; set; }
        [Url]
        public string? PostImageUrl { get; set; }
        [Url]
        public string? PostVideoUrl { get; set; }
        [Url]
        public string? PostAttachedLinkUrl { get; set; }
        public string? PostAttachedLinkUrlSubject { get; set; }
    }
}
