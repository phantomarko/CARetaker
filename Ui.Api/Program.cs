using Application;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Infrastructure;
using Infrastructure.Security.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Infra and App services
builder.Services.AddApplication();
builder.Services.AddPersistence();
builder.Services.AddSecurity();

// API services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument();
builder.Services.AddAuthenticationJwtBearer(s => {}, options =>
{
    var jwtOptions = builder.Configuration.GetSection("Jwt").Get<JwtOptions>()!;
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtOptions.Issuer,
        ValidAudience = jwtOptions.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtOptions.SecretKey))
    };
}).AddAuthorization();

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
