using Autofac;
using Autofac.Extensions.DependencyInjection;
using BootcampHomeWork.Api;
using BootcampHomeWork.Business;
using BootcampHomeWork.DataAccess;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Default FluentValidation Filterini devre dışı bırakıp kendi yazdıgımız ValidatorFilterAttribute u ekliyoruz.
builder.Services.AddControllers(option => option.Filters.Add<ValidatorFilterAttribute>()).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CountryAddDtoValidator>());

//NotFoundFilter 
builder.Services.AddScoped(typeof(NotFoundFilter<>));

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
