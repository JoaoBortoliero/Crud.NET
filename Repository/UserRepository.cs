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

        // CREATE USER
        public void CreateUser(User user)
        {
            _context.Add(user);
        }

        // DELETE USER  
        public void DeleteUser(User user)
        {
            _context.Remove(user);
        }

        // SEARCH USER
        public async Task<IEnumerable<User>> SearchUser()
        {
            return await _context.User.ToListAsync();
        }

        // SEARCH USER BY ID
        public async Task<User> SearchUserById(int id)
        {
            return await _context.User
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        // UPDATE USER
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