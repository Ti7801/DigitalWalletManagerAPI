using BibliotecaBusiness.DTOs;
using BibliotecaBusiness.Exceptions;
using BibliotecaBusiness.Models;
using BibliotecaBusiness.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DigitalWalletManagerAPI.Controllers
{
    [ApiController]
    [Route("api/carteira")]
    public class CarteiraDigitalController : ControllerBase
    {
        private readonly CriarCarteiraDigitalService _criarCarteiraDigitalService;
        private readonly ConsultarSaldoDaCarteiraService _consultarSaldoDaCarteiraService;
        private readonly AtualizarSaldoCarteiraService _atualizarSaldoCarteiraService;

        public CarteiraDigitalController(CriarCarteiraDigitalService criarCarteiraDigitalService,
                                         ConsultarSaldoDaCarteiraService consultarSaldoDaCarteiraService,
                                         AtualizarSaldoCarteiraService atualizarSaldoCarteiraService) 
        {
            _criarCarteiraDigitalService = criarCarteiraDigitalService;
            _consultarSaldoDaCarteiraService = consultarSaldoDaCarteiraService;
            _atualizarSaldoCarteiraService = atualizarSaldoCarteiraService;

        }

        [HttpPost("criar-carteira")]
        [ProducesResponseType(typeof(CarteiraDigital), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CarteiraDigital>> CriarCarteiraDigital(CriarCarteiraDigitalDto carteiraDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).SingleOrDefault();
                return BadRequest(errors);
            }

            var carteira = new CarteiraDigital
            {
                Id = Guid.NewGuid(),    
                Saldo = 0m,
                UsuarioId = carteiraDto.UsuarioId,  
            };

            ServiceResult serviceResult = await _criarCarteiraDigitalService.CadastrarCarteiraDigital(carteira);

            if (!serviceResult.Success)
            {
                return Problem(statusCode:StatusCodes.Status500InternalServerError);
            }

            return CreatedAtAction(nameof(CriarCarteiraDigital), carteira);
        }

        [HttpGet("consultar/{usuarioId:Guid}/{carteiraId:Guid}")]
        [ProducesResponseType(typeof(decimal?), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CarteiraDigital>> ConsultarSaldoDaCarteira(Guid usuarioId, Guid carteiraId)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).SingleOrDefault();
                return BadRequest(errors);
            }

            ServiceResult<CarteiraDigital?> serviceResult = await _consultarSaldoDaCarteiraService.ObterSaldoCarteiraUsuario(usuarioId, carteiraId);


            if (!serviceResult.Sucess)
            {
                return Problem(statusCode:StatusCodes.Status500InternalServerError);
            }

            return serviceResult.Value;
        }


        [HttpPut("adicionar-saldo")]
        [ProducesResponseType(typeof(ServiceResult<CarteiraDigital>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CarteiraDigital?>> AdicionarSaldoCarteira(AdicionarSaldoDto adicionarSaldoDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).SingleOrDefault();
                return BadRequest(errors);
            }

            ServiceResult<CarteiraDigital?> serviceResult = await _atualizarSaldoCarteiraService.AtualizarSaldoCarteira(adicionarSaldoDto.UsuarioId, adicionarSaldoDto.CarteiraId, adicionarSaldoDto.Valor);


            if (!serviceResult.Sucess)
            {
                return Problem(statusCode: StatusCodes.Status500InternalServerError);
            }

            return serviceResult.Value;
        }
    }
}
