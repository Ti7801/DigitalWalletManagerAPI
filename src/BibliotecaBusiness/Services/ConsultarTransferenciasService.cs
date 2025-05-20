using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.DTOs;
using BibliotecaBusiness.Exceptions;
using BibliotecaBusiness.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBusiness.Services
{
    public class ConsultarTransferenciasService
    {
        private readonly ITransferenciaRepository _transferenciaRepository;
        private readonly ICarteiraDigitalRepository _carteiraDigitalRepository; 
        private readonly ILogger<ConsultarTransferenciasService> _logger;

        public ConsultarTransferenciasService(ITransferenciaRepository transferenciaRepository,
                                               ICarteiraDigitalRepository carteiraDigitalRepository,
                                               ILogger<ConsultarTransferenciasService> logger) 
        {
            _transferenciaRepository = transferenciaRepository;
            _carteiraDigitalRepository = carteiraDigitalRepository; 
            _logger = logger;   
        }

        public async Task<ServiceResult<List<Transferencia>>> ObterTransferencias(FiltroTransferenciaRealizadasDto transferenciasRealizadasDto)
        {
            ServiceResult<List<Transferencia>> serviceResult = new ServiceResult<List<Transferencia>>();

            try
            {
                serviceResult.Sucess = true;

                var listTransferencias = await _transferenciaRepository.ObterTransferenciasPorCarteiraAsync(transferenciasRealizadasDto.CarteiraId, transferenciasRealizadasDto.DataInicio, transferenciasRealizadasDto.DataFim);

                serviceResult.Value = listTransferencias;

                return serviceResult;

            }
            catch (Exception ex)
            {
                serviceResult.Sucess = false;
                serviceResult.Erros.Add(ex.Message);
                _logger.LogError(ex, "Erro ao obter as transferências para o usuário com ID: {UsuarioId}. Detalhes do erro: {ErroMessage}", transferenciasRealizadasDto.UsuarioId, ex.Message);

                return serviceResult;
            }
        }
    }
}
