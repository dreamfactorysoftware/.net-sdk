namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.Event;

    internal partial class SystemApi
    {
        #region --- Helpers ---

        private async Task<TResponseRecord> QueryRecordAsync<TResponseRecord>(string resource, string resourceIdentifier, SqlQuery query)
            where TResponseRecord : class, new()
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource");
            }

            if (resourceIdentifier == null)
            {
                throw new ArgumentNullException("resourceIdentifier");
            }

            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            IHttpAddress address = baseAddress.WithResource(resource, resourceIdentifier);
            address = address.WithSqlQuery(query);

            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);
            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<TResponseRecord>(response.Body);
        }

        #endregion
    }
}
