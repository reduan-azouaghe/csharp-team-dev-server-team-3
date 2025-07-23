using exercise.models;
using exercise.wwwapi.Data;
using exercise.wwwapi.Endpoints;
using exercise.wwwapi.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Scalar.AspNetCore;
using System;
using System.Diagnostics;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IRepository<User>, Repository<User>>();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});



//builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("tds"));
builder.Services.AddDbContext<DataContext>(options => {    
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString"));
    options.LogTo(message => Debug.WriteLine(message));

});
var app = builder.Build();

app.MapOpenApi();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "Demo API");
    
    
});
app.MapScalarApiReference();

app.UseHttpsRedirection();

app.ConfigureUserEndpoints();
app.ConfigurePostEndpoints();
app.ConfigureCohortEndpoints();
app.ConfigureLogEndpoints();

app.Run();

