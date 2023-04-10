namespace Assignment_ThangNVPH25980.ViewModels
{
    public class CartView
    {
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}
