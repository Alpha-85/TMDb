using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using TMDb.Application;
using TMDb.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
configuration.AddEnvironmentVariables();

var services = builder.Services;
services.AddInfrastructure();
services.AddApplication();
services.AddRouting(opt => opt.LowercaseUrls = true);

builder.Services.AddControllers()
    .AddJsonOptions(opt => opt.JsonSerializerOptions.Converters
        .Add(new JsonStringEnumConverter()));

builder.Services.AddMvc()
    .AddFluentValidation();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" }));


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
