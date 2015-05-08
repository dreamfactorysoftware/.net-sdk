namespace DreamFactory.Http
{
    using System;
    using System.IO;

    /// <summary>
    /// Represents generic HTTP response.
    /// </summary>
    public class HttpResponse : IHttpResponse
    {
        private string bodyString;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpResponse"/> class.
        /// </summary>
        /// <param name="request">Originating request.</param>
        /// <param name="code">HTTP status code.</param>
        /// <param name="raw">HTTP response raw body</param>
        public HttpResponse(IHttpRequest request, int code, byte[] raw)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (raw == null)
            {
                throw new ArgumentNullException("raw");
            }

            Request = request;
            Code = code;
            RawBody = raw;
        }

        /// <inheritdoc />
        public IHttpRequest Request { get; private set; }

        /// <inheritdoc />
        public int Code { get; private set; }

        /// <inheritdoc />
        public string Body
        {
            get
            {
                if (bodyString == null)
                {
                    ReadBody();
                }

                return bodyString;
            }
        }

        /// <inheritdoc />
        public byte[] RawBody { get; private set; }

        private void ReadBody()
        {
            using (MemoryStream memory = new MemoryStream(RawBody))
            {
                bodyString = new StreamReader(memory).ReadToEnd();
            }
        }
    }
}
