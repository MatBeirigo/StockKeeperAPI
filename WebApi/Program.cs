using Domain.Interfaces.Generica;
using Domain.Interfaces.ICategoria;
using Domain.Interfaces.IEstoque;
using Domain.Interfaces.IFornecedor;
using Domain.Interfaces.IFuncionario;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IProduto;
using Domain.Interfaces.IUnidades;
using Domain.Servicos;
using Entitities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio;
using Infra.Repositorio.Generics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApi.Token;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextBase>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ContextBase>();

//Interface e repositorio 
builder.Services.AddSingleton(typeof(InterfaceGenerica<>), typeof(RepositoryGenerics<>));
builder.Services.AddSingleton<InterfaceFuncionario, RepositorioFuncionario>();
builder.Services.AddSingleton<InterfaceProduto, RepositorioProduto>();
builder.Services.AddSingleton<InterfaceCategoria, RepositorioCategoria>();
builder.Services.AddSingleton<InterfaceUnidades, RepositorioUnidades>();
builder.Services.AddSingleton<InterfaceFornecedor, RepositorioFornecedor>();
builder.Services.AddSingleton<InterfaceEstoque, RepositorioEstoque>();

//Interface e serviço
builder.Services.AddSingleton<IFuncionarioServico, FuncionarioServico>();
builder.Services.AddSingleton<IProdutoServico, ProdutoServico>();
builder.Services.AddSingleton<IEstoqueServico, EstoqueServico>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = "Teste.Security.Bearer",
        ValidAudience = "Teste.Security.Bearer",
        IssuerSigningKey = JwtSecurityKey.Create("Secret_Key-12345678")
    };

    option.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
            return Task.CompletedTask;
        },
        OnTokenValidated = context =>
        {
            Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
            return Task.CompletedTask;
        }
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var devCliente = "http://localhost:4200";
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().WithOrigins(devCliente));

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
