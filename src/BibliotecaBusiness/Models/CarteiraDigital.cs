using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBusiness.Models
{
    public class CarteiraDigital
    {
        public Guid Id { get; set; }
        public decimal Saldo { get; set; } 
        public Guid UsuarioId { get; set; }  
    }
}
