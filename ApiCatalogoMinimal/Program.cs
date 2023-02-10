using ApiCatalogoMinimal.ApiEndpoints;
using ApiCatalogoMinimal.AppServicesExtensions;
using ApiCatalogoMinimal.Context;
using ApiCatalogoMinimal.Models;
using ApiCatalogoMinimal.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddApiSwagger();
builder.AddPersistence();
builder.Services.AddCors();
builder.AddAuthenticationJwt();

var app = builder.Build();

app.MapAutenticacaoEndpoint();

app.MapCategoriasEndpoints();

app.MapProdutosEndpoints();

//app.MapGet("/", () => "Catálogo de Produtos 2023").ExcludeFromDescription();

var environment = app.Environment;

app.UseExceptionHandling(environment)
    .UseSwaggerBuilder()
    .UseAppCors();

app.UseAuthentication();
app.UseAuthorization();

app.Run();

