using GestaoGastoResidencial.App.UseCases.CategoriaUseCase;
using GestaoGastoResidencial.App.UseCases.PessoaUseCase;
using GestaoGastoResidencial.App.UseCases.TransacaoUseCase;
using GestaoGastoResidencial.Domain.Interfaces.Repositories;
using GestaoGastoResidencial.Infra.Context;
using GestaoGastoResidencial.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BancoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionando injeção de dependência para repositórios e casos de uso
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ITransacaoRepository, TransacaoRepository>();

builder.Services.AddScoped<IPessoaUseCases, PessoaUseCases>();
builder.Services.AddScoped<ICategoriaUseCases, CategoriaUseCases>();
builder.Services.AddScoped<ITransacaoUseCases, TransacaoUseCases>();

// Configuração do CORS para permitir requisições do frontend
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.AllowAnyHeader()               
                   .AllowAnyMethod()               
                   .AllowCredentials()
                   .WithOrigins("http://localhost:5173");
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
