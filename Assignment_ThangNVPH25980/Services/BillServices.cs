using Assignment_ThangNVPH25980.IServices;
using Assignment_ThangNVPH25980.Migrations;
using Assignment_ThangNVPH25980.Models;

namespace Assignment_ThangNVPH25980.Services
{

    public class BillServices : IBillServices
    {
        OuteDBContext context;
        public BillServices()
        {
            context = new OuteDBContext();
        }
        public bool Add(Bill bill)
        {
            try
            {
                context.Bill.Add(bill);
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
                var p = context.Bill.Find(Id);
                context.Bill.Remove(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Bill> GetAllBill()
        {
            return context.Bill.ToList();
        }

        public Bill GetBillById(Guid Id)
        {
            return context.Bill.FirstOrDefault(x => x.Id == Id);
        }

        public List<Bill> GetBillByName(string Name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Bill bill)
        {
            try
            {
                var p = context.Bill.Find(bill.Id);
                p.Status = bill.Status;
                context.Bill.Update(p);
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
