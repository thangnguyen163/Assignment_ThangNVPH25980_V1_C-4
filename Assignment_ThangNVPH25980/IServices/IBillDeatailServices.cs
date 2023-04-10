using Assignment_ThangNVPH25980.Models;

namespace Assignment_ThangNVPH25980.IServices
{
    public interface IBillDeatailServices
    {
        public bool Add(BillDetails billDetails);
        public bool Update(BillDetails billDetails);
        public bool Delete(Guid Id);
        public List<BillDetails> GetAllBillDetail();
        public List<BillDetails> GetBillDetailById(Guid Id);
        public List<BillDetails> GetBillDetailtByName(string Name);
    }
}
