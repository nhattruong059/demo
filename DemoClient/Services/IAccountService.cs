using DemoClient.Models;

namespace DemoClient.Services
{
    public interface IAccountService
    {
        Task<AccountDto?> Login(string email, string password);
        Task<List<AccountDto>?> FindAll();
        Task<bool> Create(AccountDto acc);
    }
}
