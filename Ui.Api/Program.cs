using Application;
using FastEndpoints;
using FastEndpoints.Swagger;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ui.Api;

var builder = WebApplication.CreateBuilder(args);

// Infra and App services
builder.Services.AddApplication();
builder.Services.AddPersistence();
builder.Services.AddSecurity();

// API services
builder.Services.AddControllers(); // try to remove this line
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument();

builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// FastEndpoints
app.UseDefaultExceptionHandler();
app.UseFastEndpoints();

if (app.Environment.IsDevelopment())
{
    // FE swagger
    app.UseSwaggerGen();
}

app.Run();
