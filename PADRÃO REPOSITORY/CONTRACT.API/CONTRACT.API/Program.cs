using CONTRACT.API.Repository;
using CONTRACT.API.Repository.Interfaces;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<SqlConnection>(_ => new SqlConnection(builder.Configuration.GetConnectionString("DBCONNECTION")));

builder.Services.AddScoped<IContractRepository, ContractRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
