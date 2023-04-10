using Assignment_ThangNVPH25980.Models;

namespace Assignment_ThangNVPH25980.IService
{
    public interface IAccountServices
    {
        public bool Add(Accounts accounts);
        public bool Update(Accounts accounts);
        public bool Delete(Guid Id);
        public List<Accounts> GetAllAccounts();
        public Accounts GetAccountById(Guid Id);
        public List<Accounts> GetAccountByName(string Name);
    }
}
