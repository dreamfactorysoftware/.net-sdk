namespace DreamFactory.Http
{
    using System;

    /// <summary>
    /// Represents generic HTTP request.
    /// </summary>
    public class HttpRequest : IHttpRequest
    {
        internal const string TunnelingHeader = "X-HTTP-Method";

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequest"/> class.
        /// </summary>
        /// <param name="method">HTTP method.</param>
        /// <param name="url">URL.</param>
        /// <param name="headers">Headers.</param>
        /// <param name="body">Body.</param>
        public HttpRequest(HttpMethod method, string url, HttpHeaders headers, object body = null)
        {
            HttpUtils.CheckUrlString(url);

            if (headers == null)
            {
                throw new ArgumentNullException("headers");
            }

            Method = method;
            Url = url;
            Body = body;
            Headers = headers;
        }

        /// <inheritdoc />
        public HttpMethod Method { get; private set; }

        /// <inheritdoc />
        public string Url { get; private set; }

        /// <inheritdoc />
        public object Body { get; private set; }

        /// <inheritdoc />
        public HttpHeaders Headers { get; private set; }

        /// <inheritdoc />
        public void SetTunneling(HttpMethod method)
        {
            string httpMethod = HttpUtils.GetHttpMethodName(Method);
            Headers = Headers.WithHeader(TunnelingHeader, httpMethod);
            Method = method;
        }
    }
}
