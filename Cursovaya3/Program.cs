using BLL;
using Cursovaya3.AutoMapperConfigs;
using DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DatabasesContext>(options => options.UseSqlServer(connection));
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IDatabasesRepository, DatabasesRepository>();
builder.Services.AddScoped<IDBService, DBService>();
builder.Services.AddAutoMapper(typeof(InsertDataProfile));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
