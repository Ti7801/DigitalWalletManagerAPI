using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBusiness.Services
{
    public class CadastrarUsuarioService
    {
        private readonly ILogger<CadastrarUsuarioService> _logger;
        private readonly UserManager<Usuario> _userManager;


        public CadastrarUsuarioService(ILogger<CadastrarUsuarioService> logger, UserManager<Usuario> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<ServiceResult<IdentityResult?>> CreateIdentityUser(Usuario user, string password)
        {
            ServiceResult<IdentityResult?> serviceResult = new ServiceResult<IdentityResult?>();

            try
            {
                var result = await _userManager.CreateAsync(user, password);
                serviceResult.Value = result;
 
                if (result.Succeeded)
                {
                    serviceResult.Sucess = true;
                }
                else
                {
                    serviceResult.Sucess = false;                 

                    foreach (var error in result.Errors)
                    {
                        serviceResult.Erros.Add($"{error.Code}: {error.Description}");
                    }
                }
            }
            catch (Exception ex) 
            {
                serviceResult.Sucess = false;
                serviceResult.Erros.Add($"Exceção inesperada: {ex.Message}");
                _logger.LogError(ex, "Erro ao tentar criar o usuário!");
            }

            return serviceResult;
        }
    }
}
