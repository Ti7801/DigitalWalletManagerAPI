using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;
using BibliotecaData.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using BibliotecaBusiness.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<AppDbContext>(
    (DbContextOptionsBuilder optionsBuilder) =>
    {
        string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseNpgsql(connectionString);
    },
    ServiceLifetime.Scoped
);


builder.Services.AddScoped<CadastrarUsuarioService>();

builder.Services.AddScoped<ICarteiraDigitalRepository, CarteiraDiditalRepository>();
builder.Services.AddScoped<CriarCarteiraDigitalService>();
builder.Services.AddScoped<ConsultarSaldoDaCarteiraService>();
builder.Services.AddScoped<AtualizarSaldoCarteiraService>();



builder.Services.AddScoped<ITransferenciaRepository, TransferenciaRepository>();
builder.Services.AddScoped<CriarTransferenciaService>();
builder.Services.AddScoped<ConsultarTransferenciasServices>();


//Autentication - Uso da Identidade - USUARIO/PERFIL
builder.Services.AddIdentity<Usuario, IdentityRole<Guid>>(options =>
{
    // Configurações a identidade para permitir espaços no UserName
    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+~àáâãäåçèéêìíîïòóôõöùúûü ";
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
})
.AddEntityFrameworkStores<AppDbContext>()
//.AddErrorDescriber<IdentityPortugueseErrorDescriber>()
.AddDefaultTokenProviders(); // Para recuperação de senha e confirmação de e-mail


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseAuthentication();
//app.UseAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
