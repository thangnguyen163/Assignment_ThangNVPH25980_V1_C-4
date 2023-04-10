using Assignment_ThangNVPH25980.IServices;
using Assignment_ThangNVPH25980.Migrations;
using Assignment_ThangNVPH25980.Models;

namespace Assignment_ThangNVPH25980.Services
{
    public class SizeServices : ISizeServices
    {
        OuteDBContext context;
        public SizeServices()
        {
            context = new OuteDBContext();
        }

        public bool Add(Size size)
        {
            try
            {
                context.Size.Add(size);
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
                var p = context.Size.Find(Id);
                context.Size.Remove(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Size> GetAllSize()
        {
            return context.Size.ToList();
        }

        public Size GetSizeById(Guid Id)
        {
            return context.Size.FirstOrDefault(x => x.Id == Id);
        }

        public List<Size> GetSizeByName(string Name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Size size)
        {
            try
            {
                var p = context.Size.Find(size.Id);
                p.Name = size.Name;
                p.Status = size.Status;
                context.Size.Update(p);
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
