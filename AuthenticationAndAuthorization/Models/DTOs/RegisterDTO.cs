using System.ComponentModel.DataAnnotations;

namespace AuthenticationAndAuthorization.Models.DTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "UserName Alani zorunludur.")]
        [Display(Name = "User Name")]
        [MinLength(2, ErrorMessage = "UserName alani en az 2 karakter olmalıdır.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email Alani zorunludur.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "email adresini yanlış girdiniz")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Sifre Alani zorunludur.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "TcKimlik No")]
        public string TcNo { get; set; }
    }
}
