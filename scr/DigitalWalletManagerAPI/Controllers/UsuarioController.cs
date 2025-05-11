using BibliotecaBusiness.DTOs;
using BibliotecaBusiness.Models;
using BibliotecaBusiness.Services;
using Microsoft.AspNetCore.Mvc;

namespace DigitalWalletManagerAPI.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly CadastrarUsuarioService _cadastrarUsuarioService;  

        public UsuarioController(CadastrarUsuarioService cadastrarUsuarioService) 
        { 
            _cadastrarUsuarioService = cadastrarUsuarioService; 
        }

        [HttpPost("cadastrar-usuario")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Guid>> CadastrarUsuario(UsuarioDto usuarioDto)
        {
            if (!ModelState.IsValid)
            {
                var erros = ModelState.Values.SelectMany(X => X.Errors).Select(erros => erros.ErrorMessage).SingleOrDefault();

                return BadRequest(erros);
            }

            var usuario = new Usuario()
            {
                Id = Guid.NewGuid(),
                UserName = usuarioDto.name,
                PhoneNumber = usuarioDto.PhoneNumber,
                PhoneNumberConfirmed = true,
                Email = usuarioDto.email,
                EmailConfirmed = true,
            };

            var serviceResult = await _cadastrarUsuarioService.CreateIdentityUser(usuario, usuarioDto.Password);

            if (!serviceResult.Sucess)
            {
                return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
                {
                    { "Erros", serviceResult.Erros.ToArray() }
                }));
            }
          
            return CreatedAtAction(nameof(CadastrarUsuario), usuario.Id);
        }
    }
}
