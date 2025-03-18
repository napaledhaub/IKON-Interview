using interview.Data;
using interview.Models;
using interview.Services;
using Microsoft.EntityFrameworkCore;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(conString));
builder.Services.Configure<APISettings>(builder.Configuration.GetSection("APISettings"));
builder.Services.AddHttpClient<IPlaceholderService, PlaceholderService>();
builder.Services.AddScoped<IPlaceholderService, PlaceholderService>();

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
