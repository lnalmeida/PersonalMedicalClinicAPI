using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PMC.Data.Context;

var builder = WebApplication.CreateBuilder(args);

string strConnection = builder.Configuration.GetConnectionString("PMC_Connection");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PMC_Context>(options => options.UseSqlServer(strConnection));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Personal Medical Clinic API", Version = "v1" });
});

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
