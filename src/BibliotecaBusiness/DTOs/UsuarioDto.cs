using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBusiness.DTOs
{
    public class UsuarioDto
    {
        [Display(Name = "name")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string name { get; set; } = string.Empty;

        [Display(Name = "phonenumber")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Display(Name = "email")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string email { get; set; } = string.Empty;

        [Display(Name = "password")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(maximumLength: 30, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;
    }
}
