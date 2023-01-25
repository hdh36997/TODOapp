using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TODO_App.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Wymagany jest login!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Wymagane jest hasło!")]
        [DisplayName("Hasło")]
        public string Password { get; set; }
    }
}
