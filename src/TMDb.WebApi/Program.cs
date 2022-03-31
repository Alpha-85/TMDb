using System.Reflection;
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
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1.0",
        Title = "TMDb Api",
        Description = "An ASP.NET Core Web API for CodeAssessment"
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

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
