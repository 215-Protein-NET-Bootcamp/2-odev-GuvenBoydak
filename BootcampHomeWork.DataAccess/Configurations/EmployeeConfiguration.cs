using BootcampHomework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BootcampHomeWork.DataAccess
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            //builder.Property(x => x.EmployeeName).IsRequired().HasColumnType("nvarchar(20)");
        }
    }
}
