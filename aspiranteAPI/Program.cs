using aspiranteAPI.DTOs;
using aspiranteAPI.Models;
using aspiranteAPI.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
//EntityFramework
builder.Services.AddDbContext<AspiranteContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("thisConnection")));
//Validator Fluent
builder.Services.AddScoped<IValidator<AspiranteModifiedDto>, AspiranteModifierValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.UseHttpsRedirection();
app.Run();