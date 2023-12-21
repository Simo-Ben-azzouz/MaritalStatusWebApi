using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using patrickLearn.Data;
using patrickLearn.Models;
using patrickLearn.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// var cnx="Server=Localhost;Database=Marital_Status;user=root";
builder.Services.AddDbContext<DataContext>(
    opt => opt.UseMySql(
        builder.Configuration.GetConnectionString("Default"),
        new MariaDbServerVersion(new Version(8, 2, 0)) // Adjust the version as needed
    )
);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IHusbandService,HusbandService>();
builder.Services.AddScoped<IAuthRepository,AuthRepository>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    { 
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF32
                    .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value!)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
var app = builder.Build();

// builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//add

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); //add 

app.UseAuthorization();

app.MapControllers();

app.Run();
