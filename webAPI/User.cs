
using System.ComponentModel.DataAnnotations;

namespace webAPI
{
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
    public class UserLogIn
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}