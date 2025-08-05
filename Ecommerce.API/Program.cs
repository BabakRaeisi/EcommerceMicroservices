using Ecommerce.API.Middleware;
using Ecommerce.Core;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Mappers;
using Ecommerce.Infrastructure;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

   
builder.Services.AddInfrastructure();
            
builder.Services.AddCore();

builder.Services.AddControllers().AddJsonOptions(options=>
options.JsonSerializerOptions.Converters.Add(new  JsonStringEnumConverter())
);
builder.Services.AddAutoMapper(
    typeof(ApplicationUserMappingProfile).Assembly,
    typeof(RegisterRequestMappingProfile).Assembly
    );
//fluent validation
 builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt=>
{
    opt.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.Configure<JWTSetting>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Secret"]))
        };
    });

var app = builder.Build();

app.UseExceptionHandlingMiddleware();

app.UseCors();
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();



app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
   
