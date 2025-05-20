using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBusiness.DTOs
{
    public class TransferenciaDto
    {
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public Guid CarteiraRemetenteId { get; set; }
        public Guid CarteiraDestinatarioId { get; set; }       
    }
}

