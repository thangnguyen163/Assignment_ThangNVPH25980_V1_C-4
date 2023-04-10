namespace Assignment_ThangNVPH25980.Models
{
    public class CartDetails
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Products Product { get; set; }
    }
}
