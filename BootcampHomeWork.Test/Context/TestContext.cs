using BootcampHomework.Entities;
using BootcampHomeWork.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BootcampHomeWork.Test.Context
{
    public class TestContext : EfHomeworkDbContext
    {
        public TestContext(DbContextOptions<EfHomeworkDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Country>().HasData(
                new Country() { Id = 1, CountryName = "Türkiye", Continent = "Asya", Currency = "TRY" },
                new Country() { Id = 2, CountryName = "Belçika", Continent = "Avrupa", Currency = "EUR" },
                new Country() { Id = 3, CountryName = "Çin", Continent = "Asya", Currency = "CNY" }
                );

            modelBuilder.Entity<Folder>().HasData(
                new Folder() { Id = 1, AccessType = "Put", EmployeeId = 1 },
                new Folder() { Id = 2, AccessType = "Add", EmployeeId = 2 },
                new Folder() { Id = 3, AccessType = "Del", EmployeeId = 3 }
                );

            modelBuilder.Entity<Employee>().HasData(
                  new Employee() {Id = 1,EmployeeName = "Bradley", DepartmentId = 1 },
                  new Employee() {Id = 2,EmployeeName = "Leo", DepartmentId = 2 },
                  new Employee() { Id = 3, EmployeeName = "Bradley", DepartmentId = 3 }
                );

            modelBuilder.Entity<Department>().HasData(
                 new Department() {Id = 1,DepartmentName = "Yazılım", CountryId = 1 },
                 new Department() {Id = 2,DepartmentName = "Yazılım", CountryId = 2 },
                 new Department() { Id = 3, DepartmentName = "Yazılım", CountryId = 3 }
                );
            base.OnModelCreating(modelBuilder);
        }


    }
}

