using Crud.NET.Data;
using Crud.NET.Model;
using Microsoft.EntityFrameworkCore;

namespace Crud.NET.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            _context.Add(user);
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> SearchUser()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> SearchUserById(int id)
        {
            return await _context.User
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public void UpdateUser(User user)
        {
            _context.Update(user);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}