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
using PMC.WebAPI.Initializer;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// initializing app
var appInitializer = new AppInitializer();
appInitializer.Initialize(builder, builder.Configuration);
appInitializer.DatabaseInitilize(builder);

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
