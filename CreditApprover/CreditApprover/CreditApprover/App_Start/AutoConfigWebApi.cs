using Autofac;
using Autofac.Integration.WebApi;
using Creditapprover.Entites.DbFactory;
using CreditApprover.Data.UnitOfWorkImpl;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using Creditapprover.Entites;
using System.Web.Http;
using Creditapprover.Entites.DbModel;
using CreditApprover.Service.Interfaces.User;
using CreditApprover.Service.Services;

namespace CreditApprover.App_Start
{
    public class AutofacConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //builder.RegisterType<SampleContext>()
            //       .As<DbContext>()
            //       .InstancePerRequest();

            builder.RegisterType<DbFactory>()
                   .As<IDbFactory>()
                   .InstancePerRequest();
            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerRequest();
            builder.RegisterType<CreditApproverDbEntities>()
              .As<DbContext>()
              .InstancePerRequest();
            builder.RegisterType<UserService>()
                   .As<IUserService>()
                   .InstancePerRequest();
            //builder.RegisterType<AlbumService>()
            //       .As<IAlbumService>()
            //       .InstancePerRequest();
            //builder.RegisterType<EmployeeService>()
            //       .As<IEmployeeService>()
            //       .InstancePerRequest();

            //builder.RegisterGeneric(typeof(EntityBaseRepository<>))
            //       .As(typeof(IEntityBaseRepository<>))
            //       .InstancePerRequest();


            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }
    }
}