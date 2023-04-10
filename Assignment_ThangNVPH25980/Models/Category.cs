    namespace Assignment_ThangNVPH25980.Models
{
    public class Category
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public virtual List<Products> Products { get; set; }
    }
}
