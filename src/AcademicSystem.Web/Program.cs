using AcademicSystem.ApplicationCore.Entities;
using AcademicSystem.ApplicationCore.Interfaces;
using AcademicSystem.ApplicationCore.Services;
using AcademicSystem.Infrastructure.Data;
using AcademicSystem.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FluentValidation;
using FluentValidation.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
    configuration
        .WriteTo.Console()
        .ReadFrom.Configuration(context.Configuration));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<AcademicDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
    .AddEntityFrameworkStores<AcademicDbContext>();

var app = builder.Build();

app.UseSerilogRequestLogging();

app.UseMiddleware<AcademicSystem.Web.Middlewares.ErrorHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapIdentityApi<ApplicationUser>();

app.MapControllers();

app.Run();