using System.ComponentModel.DataAnnotations;

namespace MobileProviderSystem.Models.ViewModels
{
    public class AuthorizationModel
    {
        [Required(ErrorMessage = "Не указан логин")]
        public string Login { get; set; }
 
        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}