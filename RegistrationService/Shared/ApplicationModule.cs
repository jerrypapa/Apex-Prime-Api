using Autofac;
using RegistrationService.Application.Repositories;
using RegistrationService.CommandHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RegistrationService.Shared
{
    public class ApplicationModule : Autofac.Module
    {
        public string QueriesConnectionString { get; }
        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UsersRepository>()
                .As<IUsersRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ErrorsRepository>()
               .As<IErrorsRepository>()
               .InstancePerLifetimeScope();

            builder.RegisterType<AuditTrailRepository>()
               .As<IAuditTrailRepository>()
               .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(AddUserCommandHandler).GetTypeInfo().Assembly);

        }
    }
}
