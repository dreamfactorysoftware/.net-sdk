namespace DreamFactory.Http
{
    using System;
    using DreamFactory.Serialization;

    /// <summary>
    /// Represents generic HTTP request.
    /// </summary>
    public class HttpRequest : IHttpRequest
    {
        internal const string TunnelingHeader = "X-HTTP-Method";

        internal const string ContentTypeHeader = "Content-Type";

        internal const string AcceptHeader = "Accept";

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequest"/> class.
        /// </summary>
        /// <param name="method">HTTP method.</param>
        /// <param name="url">URL.</param>
        /// <param name="headers">Headers.</param>
        /// <param name="serializer">Object serializer instance.</param>
        public HttpRequest(HttpMethod method, string url, HttpHeaders headers, IObjectSerializer serializer = null)
        {
            HttpUtils.CheckUrlString(url);

            if (headers == null)
            {
                throw new ArgumentNullException("headers");
            }

            Method = method;
            Url = url;

            if (serializer != null)
            {
                Headers = headers.WithHeader(AcceptHeader, serializer.ContentType);
                Serializer = serializer;
            }
            else
            {
                Headers = headers;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequest"/> class.
        /// </summary>
        /// <param name="method">HTTP method.</param>
        /// <param name="url">URL.</param>
        /// <param name="headers">Headers.</param>
        /// <param name="serializer">Object serializer instance.</param>
        /// <param name="body">Body object.</param>
        public HttpRequest(HttpMethod method, string url, HttpHeaders headers, IObjectSerializer serializer, object body)
        {
            HttpUtils.CheckUrlString(url);

            if (headers == null)
            {
                throw new ArgumentNullException("headers");
            }

            if (body == null)
            {
                throw new ArgumentNullException("body");
            }

            if (serializer == null)
            {
                throw new ArgumentNullException("serializer");
            }

            Method = method;
            Url = url;
            Body = body;
            Serializer = serializer;
            Headers = headers
                .WithHeader(AcceptHeader, serializer.ContentType)
                .WithHeader(ContentTypeHeader, serializer.ContentType);
        }

        /// <inheritdoc />
        public HttpMethod Method { get; private set; }

        /// <inheritdoc />
        public string Url { get; private set; }

        /// <inheritdoc />
        public object Body { get; private set; }

        /// <inheritdoc />
        public IObjectSerializer Serializer { get; private set; }

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
