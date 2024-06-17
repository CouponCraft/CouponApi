using CouponApi.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database configuration
builder.Services.AddDbContext<CouponApiContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MyConnection"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql"),
    mySqlOptions => mySqlOptions.EnableRetryOnFailure())
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
