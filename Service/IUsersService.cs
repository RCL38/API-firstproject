using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
        Task<User> GetUserById(int id);
        Task<User> Login(UserLogIn loginUser);
        Task<User> UpdateUser(int id, User user);
        int ValidatePassword(string password);
    }
}