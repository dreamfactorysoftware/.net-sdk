namespace DreamFactory.Http
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using unirest_net.http;
    using UnirestRequest = unirest_net.request.HttpRequest;
    
    /// <summary>
    /// Unirest-powered HTTP facade.
    /// </summary>
    public class UnirestHttpFacade : IHttpFacade
    {
        private readonly Dictionary<HttpMethod, Func<string, UnirestRequest>> factoryFunctions;

        private readonly HttpHeaders customHeaders;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnirestHttpFacade"/> class.
        /// </summary>
        /// <param name="customHeaders">Optional custom headers added to each request.</param>
        public UnirestHttpFacade(HttpHeaders customHeaders = null)
        {
            this.customHeaders = customHeaders;

            factoryFunctions = new Dictionary<HttpMethod, Func<string, UnirestRequest>>
            {
                { HttpMethod.Get, Unirest.get },
                { HttpMethod.Post, Unirest.post },
                { HttpMethod.Put, Unirest.put },
                { HttpMethod.Patch, Unirest.patch },
                { HttpMethod.Delete, Unirest.delete }
            };
        }

        /// <inheritdoc />
        public async Task<IHttpResponse> SendAsync(IHttpRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            HttpHeaders headers = request.Headers;
            if (customHeaders != null)
            {
                headers = headers.WithHeaders(customHeaders);
            }

            Dictionary<string, object> dictionary = headers.GetHeaders().ToDictionary(x => x.Key, y => y.Value);

            UnirestRequest unirestRequest = factoryFunctions[request.Method](request.Url);
            if (request.Body != null)
            {
                string bodyString = request.Body as string;
                unirestRequest = bodyString != null ? unirestRequest.body(bodyString) : unirestRequest.body(request.Body);
            }

            HttpResponse<Stream> unirestResponse = await unirestRequest.headers(dictionary).asBinaryAsync();
            return new HttpResponse(request, unirestResponse.Code, unirestResponse.Raw);
        }
    }
}
