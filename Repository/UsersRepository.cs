
using Entity;
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

        public User? GetUserById(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public User? AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public User? Login(UserLogIn loginUser)
        {
            return _dbContext.Users.FirstOrDefault(u =>
                u.Email == loginUser.Email &&
                u.Password == loginUser.Password);
        }

        public User? Update(int id, User updatedUser)
        {
            User? user = _dbContext.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
                return null;

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Email = updatedUser.Email;
            user.Password = updatedUser.Password;

            _dbContext.SaveChanges();
            return user;
        }

        public void Delete(int id)
        {
            User? user = _dbContext.Users.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
        }
    }
}