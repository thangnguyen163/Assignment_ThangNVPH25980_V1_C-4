using Assignment_ThangNVPH25980.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_ThangNVPH25980.Configurations
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Bill");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedDate).HasColumnType("datetime");
            builder.HasOne(x=>x.Accounts).WithMany(p=>p.Bill).HasForeignKey(x=>x.UserId);
        }
    }
}
