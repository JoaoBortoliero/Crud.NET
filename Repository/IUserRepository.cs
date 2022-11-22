using Crud.NET.Model;

namespace Crud.NET.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> SearchUser();
        Task<User> SearchUserById(int id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);

        Task<bool> SaveChangesAsync();

    }
}