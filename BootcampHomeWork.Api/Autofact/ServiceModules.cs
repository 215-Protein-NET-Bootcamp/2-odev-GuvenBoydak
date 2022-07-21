using Autofac;
using BootcampHomeWork.Business;
using BootcampHomeWork.DataAccess;

namespace BootcampHomeWork.Api
{
    public class ServiceModules:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();


            builder.RegisterType<DPCountryRepository>().As<ICountryRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DPDepartmentRepository>().As<IDepartmentRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EFEmployeeRepository>().As<IEmployeeRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EFFolderRepository>().As<IFolderRepository>().InstancePerLifetimeScope();

            builder.RegisterType<DpCountryService>().As<ICountryService>().InstancePerLifetimeScope();
            builder.RegisterType<DpDepartmentService>().As<IDepartmentService>().InstancePerLifetimeScope();
            builder.RegisterType<EfEmployeeService>().As<IEmployeeService>().InstancePerLifetimeScope();
            builder.RegisterType<EfFolderService>().As<IFolderService>().InstancePerLifetimeScope();
        }
    }
}
