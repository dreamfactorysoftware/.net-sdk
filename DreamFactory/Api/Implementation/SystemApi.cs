namespace DreamFactory.Api.Implementation
{
    using DreamFactory.Http;
    using DreamFactory.Serialization;

    internal class SystemApi : ISystemApi
    {
        private readonly IHttpAddress baseAddress;
        private readonly IHttpFacade httpFacade;
        private readonly IContentSerializer contentSerializer;
        private readonly IHttpHeaders baseHeaders;

        public SystemApi(IHttpAddress baseAddress, IHttpFacade httpFacade, IContentSerializer contentSerializer, IHttpHeaders baseHeaders)
        {
            this.baseAddress = baseAddress;
            this.httpFacade = httpFacade;
            this.contentSerializer = contentSerializer;
            this.baseHeaders = baseHeaders;
        }
    }
}
