using Form_test.Model;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container with custom JSON options.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

// CORS configuration (optional)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RegisterPatientContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DatabaseConnection"),
    new MySqlServerVersion(new Version(8, 0, 21))));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Optional: Use exception handler middleware for production
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();

// Use the configured CORS policy (optional)
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
