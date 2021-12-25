using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace illShop.Shared.Dto.DtosRelatedProduct
{
    public class ProductReviewDto
    {
        [Key]
        public int ProductReviewId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string UserName { get; set; } = "User Of IllShop";
        public string? UserComment { get; set; }
        [Required]
        [Range(0, 5)]
        public int Rate { get; set; }
        public ProductDto Product { get; set; } = new();
    }
}
