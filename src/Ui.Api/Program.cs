using Application;
using Infrastructure;
using Ui.Api.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddApi(builder.Configuration);

var app = builder.Build();

app.ConfigureApi();
app.Run();
