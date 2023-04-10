namespace Assignment_ThangNVPH25980.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public int Status { get; set; }
        public virtual List<Accounts> Accounts { get; set; }
    }
}
