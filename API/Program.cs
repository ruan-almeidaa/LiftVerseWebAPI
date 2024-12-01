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
using Shared.VariaveisAmbiente;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
builder.Services.AddValidatorsFromAssemblyContaining<UsuarioValidation>();

//Entity Framework
builder.Services.AddDbContext<BancoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database"), sqlServerOptions =>
    {
        sqlServerOptions.CommandTimeout(60); // Tempo limite de comando em segundos
        sqlServerOptions.EnableRetryOnFailure(1); // Tenta novamente 1 vez em caso de falha
    }));

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ICredenciaisUsuarioService, CredenciaisUsuarioService>();
builder.Services.AddScoped<IVariaveisService, VariaveisService>();
builder.Services.AddScoped<ITreinoService, TreinoService>();
builder.Services.AddScoped<IExercicioFeitoService, ExercicioFeitoService>();

builder.Services.AddScoped<IOrquestraTreinoExercicioService, OrquestraTreinoExercicioService>();
builder.Services.AddScoped<IOrquestraUsuarioCredenciaisService, OrquestraUsuarioCredenciaisService>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ICredenciaisUsuarioRepository,  CredenciaisUsuarioRepository>();
builder.Services.AddScoped<ITreinoRepository, TreinoRepository>();
builder.Services.AddScoped<IExercicioFeitoRepository,  ExercicioFeitoRepository>();

builder.Services.Configure<Variaveis>(builder.Configuration.GetSection("AppSettings"));

string chaveToken = builder.Configuration["AppSettings:ChaveToken"];
string issuerToken = builder.Configuration["AppSettings:IssuerToken"];
string audienceToken = builder.Configuration["AppSettings:AudienceToken"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuerToken,
        ValidAudience = audienceToken,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveToken))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var devClient = "http.//localhost:44369";
app.UseCors(x =>
    x.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithOrigins(devClient));

app.UpdateDatabase();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
