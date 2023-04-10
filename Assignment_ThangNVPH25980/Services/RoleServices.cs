using Assignment_ThangNVPH25980.IServices;
using Assignment_ThangNVPH25980.Migrations;
using Assignment_ThangNVPH25980.Models;

namespace Assignment_ThangNVPH25980.Services
{
    public class RoleServices : IRoleServices
    {
        OuteDBContext context;
        public RoleServices()
        {
            context = new OuteDBContext();
        }
        public bool Add(Role role)
        {
            try
            {
                context.Role.Add(role);
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
                var p = context.Role.Find(Id);
                context.Role.Remove(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Role> GetAllRole()
        {
            return context.Role.ToList();
        }

        public Role GetRoleById(Guid Id)
        {
            return context.Role.FirstOrDefault(x => x.Id == Id);
        }

        public List<Role> GetRoleByName(string Name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Role role)
        {
            try
            {
                var p = context.Role.Find(role.Id);
                p.RoleName = role.RoleName;
                p.Status = role.Status;
                context.Role.Update(p);
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
