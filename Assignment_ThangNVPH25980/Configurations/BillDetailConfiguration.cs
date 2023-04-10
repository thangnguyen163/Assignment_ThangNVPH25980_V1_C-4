using Assignment_ThangNVPH25980.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_ThangNVPH25980.Configurations
{
    public class BillDetailConfiguration : IEntityTypeConfiguration<BillDetails>
    {
        public void Configure(EntityTypeBuilder<BillDetails> builder)
        {
            builder.ToTable("BillDetails");
            builder.HasKey(x => x.Id);
            
            builder.HasOne(x=>x.Product).WithMany(p=>p.BillDetails).HasForeignKey(c=>c.ProductId);
            builder.HasOne(x=>x.Bill).WithMany(p=>p.BillDetails).HasForeignKey(c=>c.BillId);
        }
    }
}
