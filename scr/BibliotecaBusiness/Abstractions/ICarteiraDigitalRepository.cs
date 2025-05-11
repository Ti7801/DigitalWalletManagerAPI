using BibliotecaBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBusiness.Abstractions
{
    public interface ICarteiraDigitalRepository
    {
        Task AdicionarCarteiraDigital(CarteiraDigital carteira);
        Task<CarteiraDigital?> ObterCarteiraDigital(Guid usuarioId, Guid carteiraId);
        Task<CarteiraDigital?> AtualizarSaldoCarteira(Guid usuarioId, Guid carteiraId);
    }
}
