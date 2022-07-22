using BootcampHomework.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BootcampHomeWork.DataAccess
{
    public class EfHomeworkDbContext:DbContext
    {
        public EfHomeworkDbContext(DbContextOptions<EfHomeworkDbContext> options):base(options)
        {
        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Country> Countries { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Assembly'deki Tüm configuration dosylarını okuyor. IEntityTypeConfiguration'den implemente eden classları reflection sayesinde buluyor.
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
