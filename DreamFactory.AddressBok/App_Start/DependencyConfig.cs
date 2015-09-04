namespace DreamFactory.AddressBook
{
    using System.Web.Mvc;
    using DreamFactory.Api;
    using DreamFactory.Rest;
    using SimpleInjector;
    using SimpleInjector.Integration.Web.Mvc;

    public class DependencyConfig
    {
        public static void Initialize()
        {
            Container container = new Container();

            RestApiVersion version = RestApiVersion.V2;
            string baseAddress = "http://dfv2.cloudapp.net:8080";
            string dbServiceName = "mysql";
            string emailServiceName = "email";
            string fileServiceName = "files";

            IRestContext context = new RestContext(baseAddress, version);

            container.Register<IDatabaseApi>(() => context.Factory.CreateDatabaseApi(dbServiceName), Lifestyle.Transient);
            container.Register<IEmailApi>(() => context.Factory.CreateEmailApi(emailServiceName), Lifestyle.Transient);
            container.Register<IFilesApi>(() => context.Factory.CreateFilesApi(fileServiceName), Lifestyle.Transient);
            container.Register<ISystemApi>(() => context.Factory.CreateSystemApi(), Lifestyle.Transient);
            container.Register<IUserApi>(() => context.Factory.CreateUserApi(), Lifestyle.Transient);
            container.Register<ICustomSettingsApi>(() => context.Factory.CreateUserCustomSettingsApi(), Lifestyle.Transient);

            container.RegisterMvcControllers();
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
