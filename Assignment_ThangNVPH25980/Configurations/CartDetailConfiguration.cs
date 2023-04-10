using Assignment_ThangNVPH25980.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_ThangNVPH25980.Configurations
{
    public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetails>
    {
        public void Configure(EntityTypeBuilder<CartDetails> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Cart).WithMany(p=>p.CartDetails).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Product).WithMany(p=>p.CartDetails).HasForeignKey(x => x.ProductId);
            
        }
    }
}
