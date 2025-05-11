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
    public class CriarTransferenciaService
    {
        private readonly ITransferenciaRepository _transferenciaRepository;
        private readonly ICarteiraDigitalRepository _carteiraDigitalRepository; 
        private readonly ILogger<CriarTransferenciaService> _logger;

        public CriarTransferenciaService(ITransferenciaRepository transferenciaRepository,
                                        ICarteiraDigitalRepository carteiraDigitalRepository,
                                        ILogger<CriarTransferenciaService> logger)
        {
            _transferenciaRepository = transferenciaRepository;
            _carteiraDigitalRepository = carteiraDigitalRepository; 
            _logger = logger;   
        }   

        public async Task<ServiceResult<Transferencia?>> CriarTransferencia(TransferenciaDto transferenciaDto)
        {
            ServiceResult<Transferencia?> serviceResult = new ServiceResult<Transferencia?>();

            try
            {
                serviceResult.Sucess = true;

                var carteiraRementente = await _carteiraDigitalRepository.ObterCarteiraDigitalPorIdCarteiraAsync(transferenciaDto.CarteiraRemetenteId);
                var carteiraDestinatario = await _carteiraDigitalRepository.ObterCarteiraDigitalPorIdCarteiraAsync(transferenciaDto.CarteiraDestinatarioId);

                if (carteiraRementente.Saldo < transferenciaDto.Valor)
                {
                    throw new SaldoInsuficienteException("Saldo insuficiente para realizar a transferência.");
                }

                var novaTransferencia = new Transferencia
                {
                    Id = Guid.NewGuid(),
                    Data = transferenciaDto.Data,
                    Valor = transferenciaDto.Valor,
                    CarteiraRemetenteId = transferenciaDto.CarteiraRemetenteId,
                    CarteiraDestinatarioId = transferenciaDto.CarteiraDestinatarioId
                };

                carteiraRementente.Saldo -= transferenciaDto.Valor;
                carteiraDestinatario.Saldo += transferenciaDto.Valor;

                var transferencia = await _transferenciaRepository.CriarTransferencia(novaTransferencia);
                serviceResult.Value = transferencia;

                return serviceResult;
            }
            catch (Exception ex)
            {
                serviceResult.Sucess = false;
                serviceResult.Erros.Add(ex.Message);
                _logger.LogError(ex, "Transferência não realizada!");

                return serviceResult;
            }

        }
    }
}
