using Autofac;
using BootcampHomeWork.Business;
using BootcampHomeWork.DataAccess;
using System.Reflection;
using Module = Autofac.Module;


namespace BootcampHomeWork.Api
{
    public class ServiceModules:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();


            Assembly apiAssembly = Assembly.GetExecutingAssembly();

            Assembly repoAssembly = Assembly.GetAssembly(typeof(EfHomeworkDbContext));

            Assembly serviceAssembly = Assembly.GetAssembly(typeof(MapperProfile));

            //apiAssembly, repoAssembly, serviceAssembly git bunlarda ara x=>.x.Name'i "Repository" ile bitenleri al ve bunlarında Interfacelerinide implemente et diyoruz.InstancePerLifetimeScope ise => Asp.Net Core daki AddScope a karşılık gelıyor.
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            //apiAssembly, repoAssembly, serviceAssembly git bunlarda ara x=>.x.Name'i "Service" ile bitenleri al ve bunlarında Interfacelerinide implemente et diyoruz.InstancePerLifetimeScope ise => Asp.Net Core daki AddScope a karşılık gelıyor.
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();



            builder.RegisterGeneric(typeof(EFBaseRepository<>)).As(typeof(IEFRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EfBaseService<>)).As(typeof(IBaseService<>)).InstancePerLifetimeScope();
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
