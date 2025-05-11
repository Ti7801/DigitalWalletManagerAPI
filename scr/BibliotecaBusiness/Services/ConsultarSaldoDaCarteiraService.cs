using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBusiness.Services
{
    public class ConsultarSaldoDaCarteiraService
    {
        private readonly ICarteiraDigitalRepository _carteiraDigitalRepository; 
        private readonly ILogger<ConsultarSaldoDaCarteiraService> _logger;

        public ConsultarSaldoDaCarteiraService(ICarteiraDigitalRepository carteiraDigitalRepository,
                                               ILogger<ConsultarSaldoDaCarteiraService> logger)
        {
            _carteiraDigitalRepository = carteiraDigitalRepository;
            _logger = logger;   
        }

        public async Task<ServiceResult<CarteiraDigital?>> ObterSaldoCarteiraUsuario(Guid usuarioId, Guid carteiraId)
        {
            ServiceResult<CarteiraDigital?> serviceResult = new ServiceResult<CarteiraDigital?>(); 
            
            try 
            {
                serviceResult.Sucess = true;
                var carteira = await _carteiraDigitalRepository.ObterCarteiraDigitalAsync(usuarioId, carteiraId);
                serviceResult.Value = carteira;

                return serviceResult;
            }
            catch (Exception ex)
            {
                serviceResult.Sucess = false;
                serviceResult.Erros.Add(ex.Message);
                _logger.LogError(ex, "Erro ao consultar saldo da carteira do usuário: {usuarioId}", usuarioId);

                return serviceResult;   
            }
        }
    }
}
