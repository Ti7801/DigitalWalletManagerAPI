using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBusiness.Services
{
    public class AtualizarSaldoCarteiraService
    {
        private readonly ICarteiraDigitalRepository _carteiraDigitalRepository; 
        private readonly ILogger<AtualizarSaldoCarteiraService> _logger;

        public AtualizarSaldoCarteiraService(ICarteiraDigitalRepository carteiraDigitalRepository,
                                            ILogger<AtualizarSaldoCarteiraService> logger)
        {
            _carteiraDigitalRepository = carteiraDigitalRepository;
            _logger = logger;   
        }

        public async Task<ServiceResult<CarteiraDigital?>> AtualizarSaldoCarteira(Guid usuarioId, Guid carteiraId)
        {
            ServiceResult<CarteiraDigital?> serviceResult = new ServiceResult<CarteiraDigital?>();

            try
            {
                serviceResult.Sucess = true;

                var carteira = await _carteiraDigitalRepository.AtualizarSaldoCarteira(usuarioId, carteiraId);

                serviceResult.Value = carteira; 

                return serviceResult;
            }
            catch (Exception ex)
            {
                serviceResult.Sucess = false;
                serviceResult.Erros.Add(ex.Message);
                _logger.LogError(ex, "Atualização do saldo não foi efetuada!");

                return serviceResult;
            }         
        }
    }
}
