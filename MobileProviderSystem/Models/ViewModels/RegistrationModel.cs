using System.ComponentModel.DataAnnotations;

namespace MobileProviderSystem.Models.ViewModels
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        public string Login { get; set; }
 
        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
 
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }
        
        [Required(ErrorMessage = "Не указана электронная почта")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Не указан номер мобильного телефона")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "Не указано ФИО пользователя")]
        public string Fio { get; set; }
        
    }
}