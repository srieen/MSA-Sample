using Person_API.DataAccess;
using Person_API.Domain;
using Person_API.Integrations;
using Person_API.Interfaces;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = builder.Configuration.GetConnectionString("SqlConnectionString");

builder.Services.AddScoped<IDbConnection>(d => new SqlConnection(connectionString));
builder.Services.AddScoped<IPersonRepository,PersonRepository>();
builder.Services.AddScoped<IProcessPersonLogic, ProcessPersonLogic>();
builder.Services.AddScoped<INewPersonAddedNotification, NewPersonAddedNotification>();


builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
