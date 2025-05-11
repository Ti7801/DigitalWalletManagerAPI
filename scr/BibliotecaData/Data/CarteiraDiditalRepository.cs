using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Exceptions;
using BibliotecaBusiness.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaData.Data
{
    public class CarteiraDiditalRepository : ICarteiraDigitalRepository
    {
        private readonly AppDbContext _appDbContext; 

        public CarteiraDiditalRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AdicionarCarteiraDigitalAsync(CarteiraDigital carteira)
        {
            _appDbContext.Carteiras.Add(carteira);  
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<CarteiraDigital> ObterCarteiraDigitalAsync(Guid usuarioId, Guid carteiraId)
        {
            var listCarteira = await _appDbContext.Carteiras.Where(x => x.UsuarioId == usuarioId).ToListAsync();

            if (listCarteira == null)
            {
                const string message = "Carteiras não foram encontradas para o usuário!";

                throw new UsuarioNaoEncontradoException(message);
            }

            CarteiraDigital carteira = listCarteira.Where(x => x.Id == carteiraId).Single();

            return carteira;
        }

        public async Task<CarteiraDigital> ObterCarteiraDigitalPorIdCarteiraAsync(Guid carteiraId)
        {
            var carteira = await _appDbContext.Carteiras.Where(x => x.Id == carteiraId).SingleOrDefaultAsync();

            if (carteira == null)
            {
                const string message = "Carteiras não foram encontradas para o usuário!";

                throw new UsuarioNaoEncontradoException(message);
            }

            return carteira;
        }

        public async Task<CarteiraDigital> AtualizarCarteiraAsync(CarteiraDigital carteira)
        {
             _appDbContext.Update(carteira);
             await _appDbContext.SaveChangesAsync();

            return carteira;  
        }
    }
}
