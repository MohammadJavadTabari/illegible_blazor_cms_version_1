using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KernelLogic.DataBaseObjects.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; } = "ProductName";
        [Required]
        [Range(1,long.MaxValue)]
        public long Price { get; set; }
        [Required]
        public string ImageUrl { get; set; } = "ImageUrl";
    }
}
