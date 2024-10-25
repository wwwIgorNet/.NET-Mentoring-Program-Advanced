using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShopping.CatalogService.Domain.Enteties;

namespace OnlineShopping.CatalogService.Infrastructure.Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {

        builder.HasKey(c => c.Id);

        builder.HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId)
            //.HasPrincipalKey(c => c.Id)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        //builder.HasMany(c => c.ChildCategories)
        //        .WithOne(cc => cc.ParentCategory)
        //        .HasForeignKey(cc => cc.ParentCategoryId)
        //        .HasPrincipalKey(pc => pc.Id)
        //        .IsRequired(false)
        //        .OnDelete(DeleteBehavior.Cascade);
    }
}
