using BootcampHomework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BootcampHomeWork.DataAccess
{
    //BaseEntityConfigurations sayesinde ortak olan propertylerimize tek bir sefer olmak üzere kısıtlamaları burda tanımladık
    public abstract class BaseEntityConfigurations : IEntityTypeConfiguration<BaseEntity> 
    {
        public void Configure(EntityTypeBuilder<BaseEntity> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired().HasColumnType("date");
            builder.Property(x => x.UpdatedDate).HasColumnType("date");
            builder.Property(x => x.DeletedDate).HasColumnType("date");
            //builder.Property(x => x.Status).HasColumnType("nvarchar(15)");
            builder.HasIndex(x => x.Id);
        }
    }
}
