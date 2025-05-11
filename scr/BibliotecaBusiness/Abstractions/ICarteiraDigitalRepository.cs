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
        Task AdicionarCarteiraDigitalAsync(CarteiraDigital carteira);
        Task<CarteiraDigital> ObterCarteiraDigitalAsync(Guid usuarioId, Guid carteiraId);
        Task<CarteiraDigital> ObterCarteiraDigitalPorIdCarteiraAsync(Guid carteiraId);
        Task<CarteiraDigital> AtualizarCarteiraAsync(CarteiraDigital carteira);
    }
}
