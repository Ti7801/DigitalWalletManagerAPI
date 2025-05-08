using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBusiness.Models
{
    public class Transferencia
    {
        public Guid Id { get; set; }
        public Guid CarteiraRemetenteId { get; set; }
        public Guid CarteiraDestinatarioId { get; set; }
    }
}
