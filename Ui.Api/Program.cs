using Application;
using FastEndpoints;
using FastEndpoints.Swagger;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();

// fastendpoints
app.UseDefaultExceptionHandler();
app.UseFastEndpoints();

if (app.Environment.IsDevelopment())
{
    // swagger
    app.UseSwaggerGen();
}

app.Run();
