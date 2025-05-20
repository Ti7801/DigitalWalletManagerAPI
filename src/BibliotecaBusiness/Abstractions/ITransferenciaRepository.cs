using BibliotecaBusiness.DTOs;
using BibliotecaBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBusiness.Abstractions
{
    public interface ITransferenciaRepository
    {
        Task<Transferencia?> CriarTransferencia(Transferencia transferencia);
        Task<List<Transferencia>> ObterTransferenciasPorCarteiraAsync(Guid carteiraId, DateTime? dataInicio, DateTime? dataFim);
    }
}
