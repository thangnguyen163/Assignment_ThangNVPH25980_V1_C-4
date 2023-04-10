using Assignment_ThangNVPH25980.Models;

namespace Assignment_ThangNVPH25980.IServices
{
    public interface IRoleServices
    {
        public bool Add(Role role);
        public bool Update(Role role);
        public bool Delete(Guid Id);
        public List<Role> GetAllRole();
        public Role GetRoleById(Guid Id);
        public List<Role> GetRoleByName(string Name);
    }
}
