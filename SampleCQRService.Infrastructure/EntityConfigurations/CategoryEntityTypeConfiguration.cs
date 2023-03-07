using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleCQRService.Infrastructure.Entities;

namespace SampleCQRService.Infrastructure.EntityConfigurations
{
    class CategoryEntityTypeConfiguration
    : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> categoryConfiguration)
        {
            categoryConfiguration.ToTable("Category");
            categoryConfiguration.HasKey(cr => cr.Id);
            categoryConfiguration.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            categoryConfiguration.Property(cr => cr.CategoryName).IsRequired();


            categoryConfiguration.HasData(BuildCategories());
        }

        private static Category[] BuildCategories()
        {
            Category[] categories =
            {
                new Category
                {
                    CategoryName = "Category1", Id = Guid.NewGuid(), Price = 189.10M
                },
                new Category
                {
                    CategoryName = "Category2", Id = Guid.NewGuid(), Price = 201.11M
                }
            };

            return categories;
        }
    }
}
