namespace DreamFactory.Rest
{
    using DreamFactory.Api;
    using DreamFactory.Api.Implementation;
    using DreamFactory.Http;
    using DreamFactory.Serialization;

    internal class ServiceFactory : IServiceFactory
    {
        private readonly IHttpAddress baseAddress;
        private readonly IHttpFacade httpFacade;
        private readonly IContentSerializer contentSerializer;
        private readonly HttpHeaders baseHeaders;

        public ServiceFactory(IHttpAddress baseAddress, IHttpFacade httpFacade, IContentSerializer contentSerializer, HttpHeaders baseHeaders)
        {
            this.baseAddress = baseAddress;
            this.httpFacade = httpFacade;
            this.contentSerializer = contentSerializer;
            this.baseHeaders = baseHeaders;
        }

        public IUserApi CreateUserApi()
        {
            return new UserApi(baseAddress, httpFacade, contentSerializer, baseHeaders);
        }

        public ISystemApi CreateSystemApi()
        {
            return new SystemApi(baseAddress, httpFacade, contentSerializer, baseHeaders);
        }

        public IFilesApi CreateFilesApi(string serviceName)
        {
            return new FilesApi(baseAddress, httpFacade, contentSerializer, baseHeaders, serviceName);
        }

        public IEmailApi CreateEmailApi(string serviceName)
        {
            return new EmailApi(baseAddress, httpFacade, contentSerializer, baseHeaders, serviceName);
        }

        public IDatabaseApi CreateDatabaseApi(string serviceName)
        {
            return new DatabaseApi(baseAddress, httpFacade, contentSerializer, baseHeaders, serviceName);
        }

        public ICustomSettingsApi CreateUserCustomSettingsApi()
        {
            return new CustomSettingsApi(baseAddress, httpFacade, contentSerializer, baseHeaders, "user");
        }

        public ICustomSettingsApi CreateSystemCustomSettingsApi()
        {
            return new CustomSettingsApi(baseAddress, httpFacade, contentSerializer, baseHeaders, "system");
        }

        public ISystemAdminApi CreateSystemAdminApi()
        {
            return new SystemApi(baseAddress, httpFacade, contentSerializer, baseHeaders);
        }

        public ISystemAppApi CreateSystemAppApi()
        {
            return new SystemApi(baseAddress, httpFacade, contentSerializer, baseHeaders);
        }

        public ISystemAppGroupApi CreateSystemAppGroupApi()
        {
            return new SystemApi(baseAddress, httpFacade, contentSerializer, baseHeaders);
        }

        public ISystemEmailTemplateApi CreateSystemEmailTemplateApi()
        {
            return new SystemApi(baseAddress, httpFacade, contentSerializer, baseHeaders);
        }

        public ISystemEventApi CreateSystemEventApi()
        {
            return new SystemApi(baseAddress, httpFacade, contentSerializer, baseHeaders);
        }

        public ISystemRoleApi CreateSystemRoleApi()
        {
            return new SystemApi(baseAddress, httpFacade, contentSerializer, baseHeaders);
        }

        public ISystemServiceApi CreateSystemServiceApi()
        {
            return new SystemApi(baseAddress, httpFacade, contentSerializer, baseHeaders);
        }

        public ISystemUserApi CreateSystemUserApi()
        {
            return new SystemApi(baseAddress, httpFacade, contentSerializer, baseHeaders);
        }
    }
}