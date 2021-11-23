using core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Config
{
    public class ProductionConfiguration:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder){
            builder.Property(p=>p.Id).IsRequired();
            builder.Property(p=>p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p=>p.Description).IsRequired().HasMaxLength(180);
            builder.Property(p=>p.Price).HasColumnType("decimal(18,2)");  
            builder.Property(p=>p.PictureUrl).IsRequired();
            builder.HasOne(b=>b.ProductBrand).WithMany().HasForeignKey(p=>p.ProductBrandId);
            builder.HasOne(p=>p.ProductType).WithMany().HasForeignKey(p=>p.ProductTypeId);

        }
        
    }
}