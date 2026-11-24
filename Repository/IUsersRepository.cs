
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> AddUser(User user);
        Task<User> GetUserByEmailAndPassword(UserLogIn loginUser);
        Task<User> GetUserById(int id);
        Task<User> UpdateUser(int id, User userToUpdate);
    }
}
