using System.ComponentModel.DataAnnotations;

namespace MvcWorkshops.Models.User
{
    public class UserRegisterViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}