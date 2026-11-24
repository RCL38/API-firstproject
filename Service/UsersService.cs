using Entity;
using Repositories;

namespace Services
{
    public class UsersService : IUserService
    {
        private readonly IUsersRepository repository;
        public UsersService(IUsersRepository repository)
        {
            this.repository = repository;
        }
        public async Task<User> GetUserById(int id)
        {
            return await repository.GetUserById(id);
        }

        public async Task<User> AddUser(User user)
        {
            if (ValidatePassword(user.Password) > 2)
                return await repository.AddUser(user);
            return null;
        }

        public async Task<User> Login(UserLogIn loginUser)
        {
            User user = await repository.GetUserByEmailAndPassword(loginUser);
            if (user == null)
                return null;
            return user;
        }
        public async Task<User> UpdateUser(int id, User user)
        {
            if (ValidatePassword(user.Password) < 3)
                return null;
            return await repository.UpdateUser(id, user);
        }

        public int ValidatePassword(string password)
        {
            int result = Zxcvbn.Core.EvaluatePassword(password).Score;
            return result;
        }
    }
}