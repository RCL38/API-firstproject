using System.Text.Json;
using Entities;

namespace Repositories
{
    public class UsersRepository
    {
        private readonly string _filePath = "users.txt";

        public User? GetUserById(int id)
        {
            if (!File.Exists(_filePath))
                return null;

            List<string> lines = File.ReadAllLines(_filePath).ToList();

            for (int i = 0; i < lines.Count; i++)
            {
                User? user = JsonSerializer.Deserialize<User>(lines[i]);
                if (user != null && user.userId == id)
                    return user;
            }
            return null;
        }

        public User? AddUser(User user)
        {
            int numberOfUsers = File.Exists(_filePath)
                ? File.ReadLines(_filePath).Count()
                : 0;

            user.userId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            File.AppendAllText(_filePath, userJson + Environment.NewLine);

            return user;
        }

        public User? Login(UserLogIn loginUser)
        {
            if (!File.Exists(_filePath))
                return null;

            foreach (string line in File.ReadLines(_filePath))
            {
                User? user = JsonSerializer.Deserialize<User>(line);
                if (user != null && user.email == loginUser.Email && user.password == loginUser.Password)
                    return user;
            }
            return null;
        }

        public User? Update(int id, User updatedUser)
        {
            if (!File.Exists(_filePath))
                return null;

            List<string> lines = File.ReadAllLines(_filePath).ToList();

            for (int i = 0; i < lines.Count; i++)
            {
                User? current = JsonSerializer.Deserialize<User>(lines[i]);
                if (current != null && current.userId == id)
                {
                    updatedUser.userId = id;
                    lines[i] = JsonSerializer.Serialize(updatedUser);
                    File.WriteAllLines(_filePath, lines);
                    return updatedUser;
                }
            }
            return null;
        }

        public void Delete(int id)
        {
        }
    }
}