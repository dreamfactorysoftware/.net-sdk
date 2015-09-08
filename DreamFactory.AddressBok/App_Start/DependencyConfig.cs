namespace DreamFactory.AddressBook
{
    using System.Web;
    using System.Web.Mvc;
    using global::DreamFactory.Api;
    using global::DreamFactory.Rest;
    using SimpleInjector;
    using SimpleInjector.Integration.Web.Mvc;

    public class DependencyConfig
    {
        public static void Initialize()
        {
            Container container = new Container();
            
            IRestContext context = new RestContext(DreamFactoryConfig.BaseAddress, DreamFactoryConfig.AppName, DreamFactoryConfig.AppApiKey, DreamFactoryConfig.SessionId, DreamFactoryConfig.Version);

            container.Register<IDatabaseApi>(() => context.Factory.CreateDatabaseApi(DreamFactoryConfig.DbServiceName), Lifestyle.Transient);
            container.Register<ISystemApi>(() => context.Factory.CreateSystemApi(), Lifestyle.Transient);
            container.Register<IUserApi>(() => context.Factory.CreateUserApi(), Lifestyle.Transient);
            container.Register<IFilesApi>(() => context.Factory.CreateFilesApi(DreamFactoryConfig.FileServiceName), Lifestyle.Transient);

            container.RegisterMvcControllers();
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
