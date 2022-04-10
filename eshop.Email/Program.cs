using eShop.Email.Model.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
 
var connection = builder.Configuration["MysqlConnection:MysqlConnectionString"];


builder.Services.AddDbContext<MySqlContext>(options => options
.UseMySql(connection,
new MySqlServerVersion
(new Version(10, 4, 21)))); builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
