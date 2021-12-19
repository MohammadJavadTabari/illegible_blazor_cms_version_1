using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace illShop.Shared.Dto.DtosRelatedProduct
{
    internal class ProductDto
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage ="please fill product name field")]
        public string ProductName { get; set; } = "ProductName";
        [Required(ErrorMessage = "please fill price field")]
        [Range(1, long.MaxValue,ErrorMessage = "price should be greater than or equal '1'")]
        public long Price { get; set; }
        [Required(ErrorMessage = "please fill Image Url field")]
        public string ImageUrl { get; set; } = "ImageUrl";
    }
}
