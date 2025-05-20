using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.DTOs;
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
    public class TransferenciaRepository  : ITransferenciaRepository
    {
        private readonly AppDbContext _appDbContext;    

        public TransferenciaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Transferencia?> CriarTransferencia(Transferencia transferencia)
        {
            _appDbContext.Transferencias.Add(transferencia);
            await _appDbContext.SaveChangesAsync();

            return transferencia;
        }


        public async Task<List<Transferencia>> ObterTransferenciasPorCarteiraAsync(Guid carteiraId, DateTime? dataInicio, DateTime? dataFim)
        {
            var query = _appDbContext.Transferencias.Where(t => t.CarteiraRemetenteId == carteiraId);

            if (dataInicio.HasValue)
            {
                query = query.Where(t => t.Data >= dataInicio.Value);
            }

            if (dataFim.HasValue)
            {
                query = query.Where(t => t.Data <= dataFim.Value);
            }

            return await query.ToListAsync();
        }
    }
}
