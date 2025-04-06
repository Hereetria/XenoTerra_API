using System.Net.WebSockets;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()   // T�m domainlerden istek kabul eder
                  .AllowAnyMethod()   // GET, POST, PUT, DELETE gibi t�m HTTP metotlar�na izin verir
                  .AllowAnyHeader();  // T�m header�lara izin verir
        });
});

// Add services to the container.
Configuration.ConfigureServices(builder);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

app.UseWebSockets();

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL();

app.Run();
