
using System.ComponentModel.DataAnnotations;

namespace webAPI
{
    public class User
    {
        [Required]
        //In C#, properties are PascalCase (UserId). To keep the data file loading, add [JsonPropertyName] or use PropertyNameCaseInsensitive = true in the JSON options
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