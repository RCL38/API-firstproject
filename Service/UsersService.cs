using Entity;
using Repositories;

namespace Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _repository;

        public UsersService(IUsersRepository repository)
        {
            _repository = repository;
        }


        public User? Login(UserLogIn loginUser)
        {
            return _repository.Login(loginUser);
        }

        public User? SignUp(User user)
        {
            if (CheckPassword(user.Password) > 2)
                return _repository.AddUser(user);

            return null;
        }

        public User? Update(int id, User updatedUser)
        {
            if (CheckPassword(updatedUser.Password) < 2)
                return null;

            return _repository.Update(id, updatedUser);
        }

        public User? GetById(int id)
        {
            return _repository.GetUserById(id);
        }

        public int CheckPassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }
    }
}