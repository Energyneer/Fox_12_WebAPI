using Domain;
using Services.Dto;
using System.Threading.Tasks;

namespace Services
{
    public interface IAccountService
    {
        User GetByUserName(string userName);
        Task<AuthResult> RegisterUser(RegisterRequest request);
        Task<AuthResult> Login(LoginRequest request);
        Task Logout();
        ValueTask<bool> IsAdmin(User user);
    }
}
