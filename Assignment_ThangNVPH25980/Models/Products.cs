namespace Assignment_ThangNVPH25980.Models
{
    public class Products
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public int AvailableQuantity { get; set; }
        public Guid SizeId { get; set; }
        public Guid ColorId { get; set; }
        public Guid CategoryId { get; set; }
        public int Status { get; set; }
        public virtual Size Size { get; set; }
        public virtual Color Color { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<BillDetails> BillDetails { get; set; }
        public virtual List<CartDetails> CartDetails { get; set; }
        
    }
}
