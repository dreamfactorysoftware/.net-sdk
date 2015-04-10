namespace DreamFactory.Rest
{
    using System;
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
            throw new NotImplementedException();
        }

        public IUserSessionApi CreateUserSessionApi()
        {
            return new UserSessionApi(baseAddress, httpFacade, contentSerializer, baseHeaders);
        }

        public ISystemApi CreateSystemApi()
        {
            throw new NotImplementedException();
        }

        public IFilesApi CreateFilesApi(string serviceName)
        {
            return new FilesApi(baseAddress, httpFacade, contentSerializer, baseHeaders, serviceName);
        }

        public IEmailApi CreateEmailApi(string serviceName)
        {
            throw new NotImplementedException();
        }

        public IDatabaseApi CreateDatabaseApi(string serviceName)
        {
            return new DatabaseApi(baseAddress, httpFacade, contentSerializer, baseHeaders, serviceName);
        }
    }
}