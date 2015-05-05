namespace DreamFactory.Http
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using unirest_net.http;
    using UnirestRequest = unirest_net.request.HttpRequest;
    
    /// <summary>
    /// Unirest-powered HTTP facade.
    /// </summary>
    public class UnirestHttpFacade : IHttpFacade
    {
        private readonly Dictionary<HttpMethod, Func<string, UnirestRequest>> factoryFunctions;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnirestHttpFacade"/> class.
        /// </summary>
        public UnirestHttpFacade()
        {
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
        public async Task<IHttpResponse> RequestAsync(IHttpRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            UnirestRequest unirestRequest = factoryFunctions[request.Method](request.Url);
            if (request.Body != null)
            {
                unirestRequest = unirestRequest.body(request.Body);
            }

            HttpResponse<Stream> unirestResponse = await unirestRequest.headers(request.Headers.Build()).asBinaryAsync().ConfigureAwait(false);
            using (MemoryStream memory = new MemoryStream())
            {
                await unirestResponse.Body.CopyToAsync(memory).ConfigureAwait(false);
                unirestResponse.Body.Dispose();
                return new HttpResponse(request, unirestResponse.Code, memory.ToArray());
            }
        }
    }
}
