using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IUsersService
    {
        User? SignUp(User user);

        User? Login(UserLogIn loginUser);

        User? Update(int id, User updatedUser);

        User? GetById(int id);

        int CheckPassword(string password);
    }
}