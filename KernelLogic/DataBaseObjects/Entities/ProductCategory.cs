using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KernelLogic.DataBaseObjects.Entities
{
    public class ProductCategory : BaseEntity
    {
        public string? CategoryName { get; set; }
        public string? Icon { get; set; }
        public List<Product>? Products { get; set; }
    }
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.Property(b => b.CategoryName).IsRequired();
            builder.Property(b => b.Icon).IsRequired();
        }
    }
}
