
using System.ComponentModel.DataAnnotations;

namespace webAPI
{
    public class User
    {
        [Required]
        //In C#, properties are written in PascalCase: UserId. users.txt stores the current names: if you rename them, set PropertyNameCaseInsensitive = true in the JsonSerializerOptions, so the existing file still loads
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
    public class UserLogIn
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}