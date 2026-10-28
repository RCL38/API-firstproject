
using System.ComponentModel.DataAnnotations;

namespace webAPI
{
    //In C#, public properties are written in PascalCase (UserId, FirstName, LastName, Email, Password).
    //If you rename them, users.txt still has the old names, so read it with
    //new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
    public class User
    {
        [Required]
        public int userId { get; set; }
        [Required]
        public string firstname { get; set; }
        [Required]
        public string lastname { get; set; }
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string password { get; set; } 
    }
    //Each class goes in its own file, named after the class (UserLogIn.cs).
    //Its properties are PascalCase too (Email, Password)
    public class UserLogIn
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}