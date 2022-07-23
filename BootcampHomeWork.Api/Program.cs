using Autofac;
using Autofac.Extensions.DependencyInjection;
using BootcampHomeWork.Api;
using BootcampHomeWork.Business;
using BootcampHomeWork.DataAccess;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Default FluentValidation Filterini devre dışı bırakıp kendi yazdıgımız ValidatorFilterAttribute u ekliyoruz.
builder.Services.AddControllers(option => option.Filters.Add<ValidatorFilterAttribute>()).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CountryAddDtoValidator>());


//AutoMapper
builder.Services.AddAutoMapper(typeof(MapperProfile));

//Autofact
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new ServiceModules()));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<DapperHomeworkDbContext>();

//Serilog
builder.Host.UseSerilog();
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();
Log.Information("Application is starting.");

//EntityFramework postgresql entegre
builder.Services.AddDbContext<EfHomeworkDbContext>(x =>
{
    x.UseNpgsql(builder.Configuration.GetConnectionString("PosgreSql"));
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Exceptionları handler etigimiz middleware
app.UseCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();



public partial class Program { }