using PROYECTOCLINICAL.Persistence.Extensions;
using PROYECTOCLINICAL.Application.UseCase.Extensions;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//se traen la inyeccion de dependencia
builder.Services.AddInjectionPersistence();
builder.Services.AddInjectionApplication();

var app = builder.Build(); //Al ocultar el AddAutomapper da error aqui

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
