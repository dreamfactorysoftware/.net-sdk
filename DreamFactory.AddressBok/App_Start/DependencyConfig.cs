namespace DreamFactory.AddressBook
{
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
            
            IRestContext context = new RestContext(DreamFactoryContext.BaseAddress, DreamFactoryContext.AppName, DreamFactoryContext.AppApiKey, DreamFactoryContext.SessionId, DreamFactoryContext.Version);

            container.Register<IDatabaseApi>(() => context.Factory.CreateDatabaseApi(DreamFactoryContext.DbServiceName), Lifestyle.Transient);
            container.Register<ISystemAdminApi>(() => context.Factory.CreateSystemAdminApi(), Lifestyle.Transient);
            container.Register<IUserApi>(() => context.Factory.CreateUserApi(), Lifestyle.Transient);
            container.Register<IFilesApi>(() => context.Factory.CreateFilesApi(DreamFactoryContext.FileServiceName), Lifestyle.Transient);

            container.RegisterMvcControllers();
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
