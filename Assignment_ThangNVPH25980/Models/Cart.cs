namespace Assignment_ThangNVPH25980.Models
{
    public class Cart
    {
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public virtual Accounts Accounts { get; set; }
        public virtual IList<CartDetails> CartDetails { get; set; }
        
    }
}
