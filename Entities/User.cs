using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        public int userId { get; set; }
        public string firstname { get; set; }

        public string lastname { get; set; }
        
        public string email { get; set; }
        
        public string password { get; set; }
    }
}
