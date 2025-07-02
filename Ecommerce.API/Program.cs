using Ecommerce.Infrastructure;
using Ecommerce.Core;
using Ecommerce.API.Middleware;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

   
builder.Services.AddInfrastructure();
            
builder.Services.AddCore();

builder.Services.AddControllers().AddJsonOptions(options=>
options.JsonSerializerOptions.Converters.Add(new  JsonStringEnumConverter())
);

            

var app = builder.Build();

app.UseExceptionHandlingMiddleware();

app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
   
