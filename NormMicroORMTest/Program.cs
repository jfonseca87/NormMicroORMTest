using Microsoft.AspNetCore.Mvc;
using NormMicroORMTest.Data;
using NormMicroORMTest.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IConnectionFactory, SqlConnectionFactory>();
builder.Services.AddScoped<DashboardRepository>();
builder.Services.AddScoped<ProyectoRepository>();
builder.Services.AddScoped<PersonaRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger UI Modified V.2");
        c.RoutePrefix = string.Empty;
    });
}

app.MapGet("/api/dashboard", async ([FromServices] DashboardRepository dashboardRepository) =>
{
    var result = await dashboardRepository.GetDashboardAsync();
    return Results.Ok(result);
})
.WithName("Dashboard");

app.MapGet("/api/projects", async ([FromServices]ProyectoRepository proyectoRepository) =>
{
    var result = await proyectoRepository.GetAllProjectsAsync();
    return Results.Ok(result);
})
.WithName("Projects");

app.MapGet("/api/people", async ([FromServices] PersonaRepository personaRepository) =>
{
    var result = await personaRepository.GetAllPersonasAsync();
    return Results.Ok(result);
})
.WithName("People");

app.Run();
