using BibliotecaBusiness.Abstractions;
using BibliotecaData.Data;
using Microsoft.EntityFrameworkCore;

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



builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
