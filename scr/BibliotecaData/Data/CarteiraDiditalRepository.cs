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

        public async Task AdicionarCarteiraDigital(CarteiraDigital carteira)
        {
            _appDbContext.Carteiras.Add(carteira);  
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<CarteiraDigital?> ObterCarteiraDigital(Guid usuarioId, Guid carteiraId)
        {
            var listCarteira = await _appDbContext.Carteiras.Where(x => x.UsuarioId == usuarioId).ToListAsync();

            if (listCarteira == null)
            {
                const string message = "Carteiras não foram encontradas para o usuário!";

                throw new UsuarioNaoEncontradoException(message);
            }

            var carteira = listCarteira.Where(x => x.Id == carteiraId).SingleOrDefault();

            return carteira;
        }

        public async Task<CarteiraDigital?> AtualizarSaldoCarteira(Guid usuarioId, Guid carteiraId)
        {
            var carteira = await ObterCarteiraDigital(usuarioId, carteiraId);

            var carteiraAtualizada = new CarteiraDigital
            {
                Id = carteira.Id,
                Saldo = carteira.Saldo,
                UsuarioId = usuarioId  
            };

            await AdicionarCarteiraDigital(carteiraAtualizada);

            return carteiraAtualizada;  
        }
    }
}
