using Application;
using FastEndpoints;
using FastEndpoints.Swagger;
using Infrastructure;
using Ui.Api.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddApi(builder.Configuration);

var app = builder.Build();

// Native
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// FastEndpoints
app.UseDefaultExceptionHandler();
app.UseFastEndpoints();

if (app.Environment.IsDevelopment())
{
    // FastEndpoints
    app.UseSwaggerGen();
}

app.Run();
