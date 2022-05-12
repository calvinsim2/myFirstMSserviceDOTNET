using Microsoft.EntityFrameworkCore;
using MStest.Data;


var builder = WebApplication.CreateBuilder(args);


//Get configuration from appsettings.json
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//link dbContext <-> db
builder.Services.AddDbContext<GameContext>(option =>
{
    option.UseSqlServer(configuration.GetConnectionString("SQLConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy",
                      builder =>
                      {
                          builder.AllowAnyOrigin();
                          builder.AllowAnyHeader();
                          builder.AllowAnyMethod();
                      });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//use Cors Policy
app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
