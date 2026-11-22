using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Repositories
{
    public interface IUsersRepository
    {
        User? GetUserById(int id);

        User? AddUser(User user);

        User? Login(UserLogIn loginUser);

        User? Update(int id, User updatedUser);

        void Delete(int id);
    }
}
