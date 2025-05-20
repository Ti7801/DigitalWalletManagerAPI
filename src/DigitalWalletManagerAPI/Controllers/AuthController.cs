using BibliotecaBusiness.DTOs;
using BibliotecaBusiness.Models;
using BibliotecaBusiness.Services;
using DigitalWalletManagerAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace DigitalWalletManagerAPI.Controllers
{
    [ApiController]
    [Route("api/conta")]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly ILogger<AuthController> _logger;
        private readonly JwtGeneratorService _jwtGeneratorService;


        public AuthController(SignInManager<Usuario> signInManager,
                           UserManager<Usuario> userManager,
                           ILogger<AuthController> logger,
                           JwtGeneratorService jwtGeneratorService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _jwtGeneratorService = jwtGeneratorService;
        }
      
        [HttpPost("registrarUsuario")]
        public async Task<ActionResult> RegistrarUsuario(RegisterUserViewModelDto registerUser)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var user = new Usuario
            {
                Id = Guid.NewGuid(),
                UserName = registerUser.Nome, 
                PhoneNumber = registerUser.Telefone,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            //Criação do usuário e definição da senha dele
            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Ok(_jwtGeneratorService.GerarJwt());
            }

            return Problem("Falha ao registrar o usuário");              
        }


        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUserViewModelDto loginUser)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(loginUser.Email);

            if (user == null)
            {
                _logger.LogWarning("Login falhou: usuário com email {Email} não encontrado", loginUser.Email);
                return Problem(statusCode: StatusCodes.Status401Unauthorized, title: "Usuário ou senha incorretos");
            }


            var result = await _signInManager.PasswordSignInAsync(user.UserName, loginUser.Password, false, true);

            if (result.Succeeded)
            {
                return Ok(_jwtGeneratorService.GerarJwt());
            }

            _logger.LogWarning("Falha no login: usuário ou senha incorretos para o email {Email}", loginUser.Email);
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: "Usuário ou senha incorretos");
        }
    }
}
