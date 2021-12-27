using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KernelLogic.DataBaseObjects.Entities
{
    public class ProductCategory : BaseEntity
    {
        public string? CategoryName { get; set; }
        public List<Product>? Products { get; set; }
    }
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.Property(b => b.CategoryName).IsRequired();
        }
    }
}
