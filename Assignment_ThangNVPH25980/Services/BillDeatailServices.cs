using Assignment_ThangNVPH25980.IServices;
using Assignment_ThangNVPH25980.Migrations;
using Assignment_ThangNVPH25980.Models;

namespace Assignment_ThangNVPH25980.Services
{
    public class BillDeatailServices : IBillDeatailServices
    {
        OuteDBContext context;
        public BillDeatailServices()
        {
            context = new OuteDBContext();
        }
        public bool Add(BillDetails billDetails)
        {
            try
            {
                context.BillDetails.Add(billDetails);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Guid Id)
        {
            try
            {
                var p = context.BillDetails.Find(Id);
                context.BillDetails.Remove(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<BillDetails> GetAllBillDetail()
        {
            return context.BillDetails.ToList();
        }

        public List<BillDetails> GetBillDetailById(Guid Id)
        {
            return context.BillDetails.Where(x => x.BillId == Id).ToList();
        }

        public List<BillDetails> GetBillDetailtByName(string Name)
        {
            throw new NotImplementedException();
        }

        public bool Update(BillDetails billDetails)
        {
            try
            {
                var p = context.BillDetails.Find(billDetails.Id);
                p.BillId = billDetails.Id;
                p.ProductId = billDetails.ProductId;
                p.Quantity=billDetails.Quantity;
                p.Price=billDetails.Price;
                context.BillDetails.Update(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
