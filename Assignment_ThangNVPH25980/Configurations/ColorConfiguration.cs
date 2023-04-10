using Assignment_ThangNVPH25980.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Assignment_ThangNVPH25980.Configurations
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.Name).HasColumnType("nvarchar(100)").IsRequired();
        }
    }
}
