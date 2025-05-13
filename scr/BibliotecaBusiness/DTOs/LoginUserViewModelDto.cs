using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBusiness.DTOs
{
    public class LoginUserViewModelDto
    {
        [Display(Name = "email")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está formato inválido")]
        public string Email { get; set; }

        [Display(Name = "password")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter {2} e {1} caracteres", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
