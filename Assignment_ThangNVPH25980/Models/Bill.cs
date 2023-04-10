namespace Assignment_ThangNVPH25980.Models
{
    public class Bill
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int Status { get; set; }
        public virtual Accounts Accounts { get; set; }
        public virtual IEnumerable<BillDetails> BillDetails { get; set; }
    }
}
