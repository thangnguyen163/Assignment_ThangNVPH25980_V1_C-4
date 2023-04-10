namespace Assignment_ThangNVPH25980.Models
{
    public class Accounts
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? NumberPhone { get; set; }
        public Guid RoleId { get; set; }
        public int? Status { get; set; }
        public virtual Role Role { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual List<Bill> Bill { get; set; }
    }
}
