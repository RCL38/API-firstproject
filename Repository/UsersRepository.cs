
using Entity;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.Text.Json;

namespace Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly storeDBContext _dbContext;

        public UsersRepository(storeDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<User> AddUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(int id, User userToUpdate)
        {
            userToUpdate.Id = id;
            _dbContext.Users.Update(userToUpdate);
            await _dbContext.SaveChangesAsync();
            return userToUpdate;
        }

        public async Task<User> GetUserByEmailAndPassword(UserLogIn loginUser)
        {
            return await _dbContext.Users.Where(user => user.Email == loginUser.Email && user.Password == loginUser.Password).FirstOrDefaultAsync();

        }
    }
}