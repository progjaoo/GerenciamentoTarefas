using FluentValidation;
using FluentValidation.AspNetCore;
using GerenciamentoTarefas.API.Middlewares;
using GerenciamentoTarefas.Application.Queries.GetAll;
using GerenciamentoTarefas.Application.Validators;
using GerenciamentoTarefas.Domain.Entidades;
using GerenciamentoTarefas.Domain.Interface;
using GerenciamentoTarefas.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<GerenciamentoTarefasContext>(options => options.UseSqlServer(connection));

//injeções de dependencia
builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();

//VALIDATOR
builder.Services.AddTransient<IValidator<Tarefa>, TarefaValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateTarefaCommandValidator>();

//MediatR
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(typeof(GetAllTarefasQueryHandler).Assembly);



builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
