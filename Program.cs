using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using KC.API.Data;
using KC.API.Mapping;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<KcDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("KcDbContext") ?? throw new InvalidOperationException("Connection string 'KcDbContext' not found.")));

// Mapping Profile
builder.Services.AddAutoMapper(typeof(MappingProfile));

//MediatR
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Register MediatR with the assembly containing handlers
builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
