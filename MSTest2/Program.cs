using Microsoft.EntityFrameworkCore;
using MSTest2.Data;

var builder = WebApplication.CreateBuilder(args);
// builder.Configuration.AddJsonFile("ocelot.json");

//Get configuration from appsettings.json
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/*builder.Services.AddOcelot();*/
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//link dbContext <-> db
builder.Services.AddDbContext<DeveloperContext>(option =>
{
    option.UseSqlServer(configuration.GetConnectionString("SQLConnection"));
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

/*app.UseOcelot().Wait();*/

app.UseAuthorization();

app.MapControllers();

app.Run();
