using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PMC.Data.Context;
using PMC.Data.Repositories;
using PMC.Manager.Implementation;
using PMC.Manager.Interfaces;
using PMC.Manager.Mappings;
using PMC.Manager.Validators;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

string strConnection = builder.Configuration.GetConnectionString("PMC_Connection") ?? string.Empty;

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(NewClientMappingProfile), typeof(UpdateClienteMappingProfile));

//maneiras descontinuadas de add fluent validation:

//.AddFluentValidation(p => p.RegisterValidatorsFromAssemblyContaining<ClienteValidator>());

//builder.Services.AddFluentValidation(p => p.RegisterValidatorsFromAssemblyContaining<ClienteValidator>());

//builder.Services.AddFluentValidation(p => p.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR"));

//validators
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");
builder.Services.AddValidatorsFromAssemblyContaining<NewClienteValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateClienteValidator>();

//contexts
builder.Services.AddDbContext<PMC_Context>(options => options.UseSqlServer(strConnection));
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteManager, ClienteManager>();

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
