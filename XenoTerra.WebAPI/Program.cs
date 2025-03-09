using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()   // Tüm domainlerden istek kabul eder
                  .AllowAnyMethod()   // GET, POST, PUT, DELETE gibi tüm HTTP metotlarýna izin verir
                  .AllowAnyHeader();  // Tüm header’lara izin verir
        });
});

// Add services to the container.
Configuration.ConfigureServices(builder);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.UseWebSockets();

app.MapControllers();

app.MapGraphQL();

app.Run();
