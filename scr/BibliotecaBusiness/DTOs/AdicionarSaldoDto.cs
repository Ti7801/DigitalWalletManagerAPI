using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBusiness.DTOs
{
    public class AdicionarSaldoDto
    {
        public Guid UsuarioId { get; set; }
        public decimal Valor {  get; set; }
        public Guid CarteiraId { get; set; }
    }
}
