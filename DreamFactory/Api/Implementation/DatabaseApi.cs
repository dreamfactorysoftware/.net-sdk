namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Serialization;

    internal class DatabaseApi : IDatabaseApi
    {
        private readonly IHttpAddress baseAddress;
        private readonly IHttpFacade httpFacade;
        private readonly IContentSerializer contentSerializer;
        private readonly IHttpHeaders baseHeaders;
        private readonly string serviceName;

        public DatabaseApi(IHttpAddress baseAddress, IHttpFacade httpFacade, IContentSerializer contentSerializer, IHttpHeaders baseHeaders, string serviceName)
        {
            this.baseAddress = baseAddress;
            this.httpFacade = httpFacade;
            this.contentSerializer = contentSerializer;
            this.baseHeaders = baseHeaders;
            this.serviceName = serviceName;
        }

        public async Task<IEnumerable<TRecord>> GetRecordsAsync<TRecord>(string tableName)
        {
            if (tableName == null)
            {
                throw new ArgumentNullException("tableName");
            }

            IHttpAddress address = baseAddress.WithResources(serviceName, tableName);

            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var recordSet = new { record = new List<TRecord>() };
            recordSet = contentSerializer.Deserialize(response.Body, recordSet);
            if (recordSet == null)
            {
                throw new DreamFactoryException("Failed to deserialize records, please check the type is matching table schema: " + typeof(TRecord).FullName);
            }

            return recordSet.record;
        }
    }
}
