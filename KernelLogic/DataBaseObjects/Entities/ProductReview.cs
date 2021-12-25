using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace KernelLogic.DataBaseObjects.Entities
{
    public class ProductReview : BaseEntity
    {
        public string UserName { get; set; } = "User Of IllShop";
        public string? UserComment { get; set; }
        [Required]
        [Range(0,5)]
        public int Rate { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
    public class ProductReviewConfiguration : IEntityTypeConfiguration<ProductReview>
    {
        public void Configure(EntityTypeBuilder<ProductReview> builder)
        {
            builder.Property(b => b.UserName).IsRequired();
            builder.Property(b => b.Rate).IsRequired();
            builder.HasOne(x => x.Product).WithMany(x => x.ProductReviews).HasForeignKey(x => x.ProductId);
        }
    }
}