using NLayer.Repository;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository.UnitOfWorks;
using NLayer.Core.Repositories;
using NLayer.Repository.Repositories;
using NLayer.Core.Services;
using NLayer.Service.Services;
using NLayer.Service.Maping;
using FluentValidation.AspNetCore;
using NLayer.Service.Validation;
using NLayer.API.Filters;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using NLayer.API.Modules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => { options.Filters.Add(new ValidateFilterAtribute());  }).AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidations>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(typeof(MapProfile));


builder.Services.AddDbContext<AppDbContext>(x=> 
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);

    });
    });

builder.Host.UseServiceProviderFactory
    (new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder=> containerBuilder.RegisterModule(new RepoServiceModule()));


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
