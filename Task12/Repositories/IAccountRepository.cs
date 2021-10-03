using Domain;

namespace Repositories
{
    public interface IAccountRepository
    {
        public User SystemUser { get; }
        User Get(string userName);
        User GetByEmail(string email);
        bool isAdmin(User user);
    }
}
