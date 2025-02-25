using ACV.ConditionReports.API.Models.DTOs;
using ACV.ConditionReports.API.Services;
using ACV.ConditionReports.API.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Serilog;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using ACV.ConditionReports.API.Repositories;
using ACV.ConditionReports.API.Repositories.Interface;
using ACV.ConditionReports.API.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration().WriteTo.File("logs/logs_.txt", rollingInterval: RollingInterval.Day).CreateLogger();

var configuration = builder.Configuration;

builder.Services.Configure<JwtSetting>(configuration.GetSection("JwtSettings"));
builder.Services.Configure<DBSetting>(builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid JWT token",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] { }
            }
        });
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            LifetimeValidator = (DateTime? notBefore, DateTime? expires, SecurityToken tokenToValidate, TokenValidationParameters @param) => expires != null ? expires > DateTime.UtcNow : false,
            ValidIssuer = configuration["JwtSettings:Issuer"],
            ValidAudience = configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddTransient<SqlConnection>(provider =>
{
    var options = provider.GetRequiredService<IOptions<DBSetting>>().Value;
    var connectionString = options.InspectionDBConnection;
    return new SqlConnection(connectionString);
});

builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IReportService, ReportService>();

builder.Services.AddTransient<GetTire>();
builder.Services.AddTransient<IReportRepository, ReportRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

try
{
    Log.Information("Application started.");
    app.Run();
}
catch (Exception ex)
{
    Log.Information("Something went wrong while starting the application!");
    Log.Error(ex.ToString());
}
finally
{
    Log.CloseAndFlush();
    Log.Information("Application stopped.");
}
