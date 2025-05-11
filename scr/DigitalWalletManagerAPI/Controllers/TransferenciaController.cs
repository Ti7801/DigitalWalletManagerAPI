using BibliotecaBusiness.DTOs;
using BibliotecaBusiness.Models;
using BibliotecaBusiness.Services;
using Microsoft.AspNetCore.Mvc;

namespace DigitalWalletManagerAPI.Controllers
{

    [ApiController]
    [Route("api/transferencia")]
    public class TransferenciaController : ControllerBase
    {
        private readonly CriarTransferenciaService _criarTransferenciaService;  
        private readonly ConsultarTransferenciasServices _consultarTransferenciasServices;  

        public TransferenciaController(CriarTransferenciaService criarTransferenciaService,
                                       ConsultarTransferenciasServices consultarTransferenciasServices) 
        {
            _criarTransferenciaService = criarTransferenciaService;
            _consultarTransferenciasServices = consultarTransferenciasServices;
        
        }

        [HttpPost("transferir-saldo")]
        [ProducesResponseType(typeof(Transferencia), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Transferencia?>> TransferirSaldo(TransferenciaDto transferencia)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).SingleOrDefault();

                return BadRequest(errors);
            }

            ServiceResult<Transferencia?> serviceResult = await _criarTransferenciaService.CriarTransferencia(transferencia);

            if (!serviceResult.Sucess)
            {
                return Problem(statusCode: StatusCodes.Status500InternalServerError);
            }

             return CreatedAtAction(nameof(TransferirSaldo), serviceResult.Value);
        }


        [HttpPost("consultar-transferencia")]
        [ProducesResponseType(typeof(Transferencia), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Transferencia>>> ConsultarTransferencias(FiltroTransferenciaRealizadasDto transferenciasRealizadas)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).SingleOrDefault();
                return BadRequest(errors);

            }

            ServiceResult<List<Transferencia>> serviceResult = await _consultarTransferenciasServices.ObterTransferencias(transferenciasRealizadas);

            if (!serviceResult.Sucess)
            {
                return Problem(statusCode: StatusCodes.Status500InternalServerError);
            }

            if (serviceResult.Value == null || !serviceResult.Value.Any())
            {
                return NoContent();  
            }

            return serviceResult.Value;
        }

    }
}
