using Entities;
using Repositories;

namespace Services
{
    public class UsersService
    {
        private readonly UsersRepository _repository = new UsersRepository();

        public User? SignUp(User user)
        {
            return _repository.AddUser(user);
        }

        public User? Login(UserLogIn loginUser)
        {
            return _repository.Login(loginUser);
        }

        public User? Update(int id, User updatedUser)
        {
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