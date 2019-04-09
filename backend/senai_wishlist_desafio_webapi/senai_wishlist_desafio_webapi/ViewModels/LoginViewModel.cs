using System.ComponentModel.DataAnnotations;

namespace senai_wishlist_desafio_webapi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "A senha deve conter no mínimo 4 caracteres")]
        public string Senha { get; set; }
    }
}
