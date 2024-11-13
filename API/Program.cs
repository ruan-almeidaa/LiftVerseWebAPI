using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Domain.Services;
using Helpers.Automapper;
using Helpers.Validation;
using Infra.Database;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using FluentValidation;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Shared.Response;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//Retorna os erros no padrão da ResponseModel
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var erros = context.ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage)
            .ToList();

        var response = new ResponseModel<object>
        {
            Dados = erros,
            Mensagem = "Erro de validação",
            HttpStatusCode = System.Net.HttpStatusCode.BadRequest
        };

        return new BadRequestObjectResult(response);
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Adiciona AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));
//Fluent validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<UsuarioEhCredenciaisDtoValidation>();

//Entity Framework
builder.Services.AddDbContext<BancoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database"), sqlServerOptions =>
    {
        sqlServerOptions.CommandTimeout(60); // Tempo limite de comando em segundos
        sqlServerOptions.EnableRetryOnFailure(1); // Tenta novamente 1 vez em caso de falha
    }));


builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ICredenciaisUsuarioService, CredenciaisUsuarioService>();
builder.Services.AddScoped<ICredenciaisUsuarioRepository,  CredenciaisUsuarioRepository>();
builder.Services.AddScoped<IOrquestracaoService, OrquestracaoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var devClient = "http.//localhost:4200";
app.UseCors(x =>
    x.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithOrigins(devClient));

app.UpdateDatabase();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
