using exercise.wwwapi.Endpoints;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

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

