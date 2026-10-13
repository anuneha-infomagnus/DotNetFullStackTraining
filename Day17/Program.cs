
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Concurrent;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer",
        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = Microsoft.OpenApi.Models.ParameterLocation.Header,
            Description = "Enter your JWT access token."
        });

    options.AddSecurityRequirement(
        new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
        {
            {
                new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Reference = new Microsoft.OpenApi.Models.OpenApiReference
                    {
                        Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
});

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var key = builder.Configuration["Jwt:Key"]
            ?? throw new InvalidOperationException(
                "JWT signing key is not configured.");

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "Day17Practice",

            ValidateAudience = true,
            ValidAudience = "Day17Client",

            ValidateLifetime = true,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(key))
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();
var refreshTokens = new ConcurrentDictionary<string, string>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/weatherforecast", () =>
{
    return Results.Ok(new
    {
        message = "Weather forecast endpoint is working."
    });
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapGet("/generate-token", (IConfiguration configuration) =>
{
    var key = configuration["Jwt:Key"];

    if (string.IsNullOrWhiteSpace(key))
    {
        return Results.Problem("JWT signing key is not configured.");
    }

    var securityKey = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(key));

    var credentials = new SigningCredentials(
        securityKey,
        SecurityAlgorithms.HmacSha256);

    var claims = new[]
    {
        new Claim(JwtRegisteredClaimNames.Sub, "admin"),
        new Claim(ClaimTypes.Role, "Admin")
    };

    var token = new JwtSecurityToken(
        issuer: "Day17Practice",
        audience: "Day17Client",
        claims: claims,
        expires: DateTime.UtcNow.AddMinutes(15),
        signingCredentials: credentials);

    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
    var refreshToken = Convert.ToBase64String(
    RandomNumberGenerator.GetBytes(32));

    refreshTokens[refreshToken] = "admin";

    return Results.Ok(new
    {
        accessToken = tokenString,
        refreshToken = refreshToken,
        tokenType = "Bearer",
        expiresInMinutes = 15
    });
})
.WithOpenApi();

app.MapGet("/admin-only", (ClaimsPrincipal user) =>
{
    return Results.Ok(new
    {
        message = "Welcome, Admin!",
        username = user.FindFirst(JwtRegisteredClaimNames.Sub)?.Value
            ?? user.FindFirst(ClaimTypes.NameIdentifier)?.Value,
        role = user.FindFirst(ClaimTypes.Role)?.Value
    });
})
.RequireAuthorization(policy => policy.RequireRole("Admin"))
.WithOpenApi();



app.MapPost("/refresh-token", (
    string refreshToken,
    IConfiguration configuration) =>
{
    if (!refreshTokens.TryRemove(refreshToken, out var username))
    {
        return Results.Unauthorized();
    }

    var key = configuration["Jwt:Key"];

    if (string.IsNullOrWhiteSpace(key))
    {
        return Results.Problem("JWT signing key is not configured.");
    }

    var securityKey = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(key));

    var credentials = new SigningCredentials(
        securityKey,
        SecurityAlgorithms.HmacSha256);

    var claims = new[]
    {
        new Claim(JwtRegisteredClaimNames.Sub, username),
        new Claim(ClaimTypes.Role, "Admin")
    };

    var token = new JwtSecurityToken(
        issuer: "Day17Practice",
        audience: "Day17Client",
        claims: claims,
        expires: DateTime.UtcNow.AddMinutes(15),
        signingCredentials: credentials);

    var accessToken = new JwtSecurityTokenHandler()
        .WriteToken(token);

    var newRefreshToken = Convert.ToBase64String(
        RandomNumberGenerator.GetBytes(32));

    refreshTokens[newRefreshToken] = username;

    return Results.Ok(new
    {
        accessToken,
        refreshToken = newRefreshToken,
        tokenType = "Bearer",
        expiresInMinutes = 15
    });
})
.WithOpenApi();
app.Run();


