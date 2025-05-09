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

builder.Services.AddScoped<ICarteiraDigitalRepository, CarteiraDiditalRepository>();



builder.Services.AddScoped<ITransferenciaRepository, TransferenciaRepository>();


builder.Services.AddScoped<CadastrarUsuarioService>();


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


////Pegando o Token e gerando a chave encodada
//var JwtSettingsSection = builder.Configuration.GetSection("JwtSettings");
//builder.Services.Configure<JwtSettings>(JwtSettingsSection);

//builder.Services.AddScoped<JwtGeneratorService>();

//builder.Services.Configure<ApiBehaviorOptions>(options =>
//{
//    options.SuppressModelStateInvalidFilter = true;
//});

//var jwtSettings = JwtSettingsSection.Get<JwtSettings>();
//var key = Encoding.ASCII.GetBytes(jwtSettings.Segredo);

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(options =>
//{
//    options.RequireHttpsMetadata = true;
//    options.SaveToken = true;
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        IssuerSigningKey = new SymmetricSecurityKey(key),
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidAudience = jwtSettings.Audiencia,
//        ValidIssuer = jwtSettings.Emissor
//    };
//});






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
