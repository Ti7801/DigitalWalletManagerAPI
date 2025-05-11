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
    public class CriarCarteiraDigitalService
    {

        private readonly ICarteiraDigitalRepository _carteiraDigitalRepository; 
        private readonly ILogger<CriarCarteiraDigitalService> _logger;

        public CriarCarteiraDigitalService(ICarteiraDigitalRepository carteiraDigitalRepository, ILogger<CriarCarteiraDigitalService> logger)
        {
            _carteiraDigitalRepository = carteiraDigitalRepository;
            _logger = logger;
        }

        public async Task<ServiceResult>  CadastrarCarteiraDigital(CarteiraDigital carteira)
        {
            ServiceResult serviceResult = new ServiceResult();

            try
            {
                serviceResult.Success = true;
                await _carteiraDigitalRepository.AdicionarCarteiraDigital(carteira);
            }
            catch (Exception ex)
            {
                serviceResult.Success= false;   
                serviceResult.Errors.Add(ex.Message);
                _logger.LogError(ex, "Erro ao cadastrar a carteira!");               
            }

            return serviceResult;   
        }
    }
}
