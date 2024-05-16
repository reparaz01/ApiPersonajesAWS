using ApiPersonajesAWS.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ApiPersonajesAWS.Data;

 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = builder.Configuration.GetConnectionString("MySqlTelevision");

builder.Services.AddTransient<RepositoryPersonajes>();
builder.Services.AddDbContext<PersonajesContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddControllers();

builder.Services.AddCors(p => p.AddPolicy("corsenabled", options =>

{
    options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>

{

    options.SwaggerDoc("v1", new OpenApiInfo()

    {

        Title = "Api Personajes AWS",
        Version = "v1"

    });

});

var app = builder.Build();


app.UseSwagger();

app.UseSwaggerUI(options =>

{

    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Personajes AWS");

    options.RoutePrefix = "";

});

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("corsenabled");

app.MapControllers();

app.Run();
