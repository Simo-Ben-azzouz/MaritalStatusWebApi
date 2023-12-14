using Microsoft.EntityFrameworkCore;
using patrickLearn.Data;
using patrickLearn.Models;
using patrickLearn.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IHusbandService,HusbandService>();

// var cnx="Server=Localhost;Database=Marital_Status;user=root";

builder.Services.AddDbContext<DataContext>(
    opt => opt.UseMySql(
        builder.Configuration.GetConnectionString("Default"),
        new MariaDbServerVersion(new Version(8, 2, 0)) // Adjust the version as needed
    )
);
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
