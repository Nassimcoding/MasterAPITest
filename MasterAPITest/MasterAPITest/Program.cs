using System.Data;
using MasterAPITest.DataGenerator;
using MasterAPITest.IModels;
using MasterAPITest.Models;
using MasterAPITest.Repository;
using Microsoft.Data.SqlClient;


var builder = WebApplication.CreateBuilder(args);

// 1. 讀 connection string
var connString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. 把 IDbConnection 本身注入（Transient：每次 request／每次注入都 new 一個新連線）
builder.Services.AddTransient<IDbConnection>(sp => new Microsoft.Data.SqlClient.SqlConnection(connString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ImplementTest>();
builder.Services.AddScoped<ProductDAL>();

builder.Services.AddSingleton<GlobalState>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
