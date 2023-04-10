using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Assignment_ThangNVPH25980.Models
{
    public class OuteDBContext:DbContext
    {
        public OuteDBContext()
        {

        }
        public OuteDBContext(DbContextOptions options): base(options)
        {

        }
        //db set
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<BillDetails> BillDetails { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Size> Size { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-FL10PIN\SQLEXPRESS;Initial Catalog=OuteApplycation;Persist Security Info=True;User ID=thang;Password=123456789");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>().HasOne<Accounts>(p=>p.Accounts).WithOne(p=>p.Cart).HasForeignKey<Cart>(p=>p.UserId);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
