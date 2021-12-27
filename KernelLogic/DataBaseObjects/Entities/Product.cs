using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace KernelLogic.DataBaseObjects.Entities
{
    public class Product : BaseEntity
    {
        public string? ProductName { get; set; }
        [Range(1,long.MaxValue)]
        public long Price { get; set; }
        public string? ImageUrl { get; set; }
        public string Desceription { get; set; } = "There is'nt any desceription for this product";
        public string? Supplier { get; set; }
        public DateTime ManufactureDate { get; set; }

        #region relations
        public List<ProductReview>? ProductReviews { get; set; }
        public int ProductCategoryId { get; set; }
        public ProductCategory? ProductCategory { get; set; }
        #endregion
    }
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(b => b.ProductName).IsRequired();
            builder.Property(b => b.Price).IsRequired();
            builder.Property(b => b.ImageUrl).IsRequired();
            builder.Property(b => b.Supplier).IsRequired();
            builder.Property(b => b.ManufactureDate).IsRequired();

            builder.HasOne(x => x.ProductCategory).WithMany(x => x.Products).HasForeignKey(x => x.ProductCategoryId);
        }
    }
}
