using BootcampHomeWork.DataAccess;
using BootcampHomeWork.Test.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BootcampHomeWork.Test
{
    public class InMemoryWebApplicationFactory<T> : WebApplicationFactory<T> where T : class
    {


        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing")
                   .ConfigureTestServices(services =>
                   {
                       var options = new DbContextOptionsBuilder<EfHomeworkDbContext>()
                                                               .UseInMemoryDatabase("testMemory").Options;
                       services.AddScoped<EfHomeworkDbContext>(provider => new TestContext(options));

                       var serviceProvider = services.BuildServiceProvider();
                       using var scope = serviceProvider.CreateScope();
                       var scopedService = scope.ServiceProvider;
                       var db = scopedService.GetRequiredService<EfHomeworkDbContext>();
                       db.Database.EnsureCreated();

                   });
        }
    }
}
