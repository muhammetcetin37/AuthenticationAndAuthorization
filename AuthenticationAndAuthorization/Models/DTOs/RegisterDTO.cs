using System.ComponentModel.DataAnnotations;

namespace AuthenticationAndAuthorization.Models.DTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "UserName alani zorunludur")]
        [Display(Name = "User Name")]
        [MinLength(2, ErrorMessage = "UserName alani en az 2 karakter olmalidir")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email alani zorunludur")]
        [DataType(DataType.EmailAddress, ErrorMessage = "email adresini yanliş giridiniz")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alani zorunludur")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "TcKimlik No")]
        public string TcNo { get; set; }

    }
}