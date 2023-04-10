using Assignment_ThangNVPH25980.Models;

namespace Assignment_ThangNVPH25980.IServices
{
    public interface IBillServices
    {
        public bool Add(Bill bill);
        public bool Update(Bill bill);
        public bool Delete(Guid Id);
        public List<Bill> GetAllBill();
        public Bill GetBillById(Guid Id);
        public List<Bill> GetBillByName(string Name);
    }
}
