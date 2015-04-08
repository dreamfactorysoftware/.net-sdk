namespace DreamFactory.Http
{
    using System;

    /// <summary>
    /// Represents generic HTTP response.
    /// </summary>
    public class HttpResponse : IHttpResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpResponse"/> class.
        /// </summary>
        /// <param name="request">Originating request.</param>
        /// <param name="code">HTTP status code.</param>
        /// <param name="body">HTTP response body.</param>
        public HttpResponse(IHttpRequest request, int code, string body)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (body == null)
            {
                throw new ArgumentNullException("body");
            }

            Request = request;
            Code = code;
            Body = body;
        }

        /// <inheritdoc />
        public IHttpRequest Request { get; private set; }

        /// <inheritdoc />
        public int Code { get; private set; }

        /// <inheritdoc />
        public string Body { get; private set; }
    }
}
