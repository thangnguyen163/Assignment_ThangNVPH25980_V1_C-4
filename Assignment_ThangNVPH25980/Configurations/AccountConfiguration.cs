using Assignment_ThangNVPH25980.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Assignment_ThangNVPH25980.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Accounts>
    {
        public void Configure(EntityTypeBuilder<Accounts> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.UserName).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x=>x.Password).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x=>x.NumberPhone).HasColumnType("nvarchar(100)").IsRequired();
            builder.HasOne(x=>x.Role).WithMany(p=>p.Accounts).HasForeignKey(x=>x.RoleId);

        }
    }
}
