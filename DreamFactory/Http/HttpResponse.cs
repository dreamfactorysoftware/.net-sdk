namespace DreamFactory.Http
{
    using System;
    using System.IO;

    /// <summary>
    /// Represents generic HTTP response.
    /// </summary>
    public class HttpResponse : IHttpResponse
    {
        private string content;

        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpResponse"/> class.
        /// </summary>
        /// <param name="request">Originating request.</param>
        /// <param name="code">HTTP status code.</param>
        /// <param name="body">HTTP response body.</param>
        public HttpResponse(IHttpRequest request, int code, Stream body)
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
        public Stream Body { get; private set; }

        /// <inheritdoc />
        public TObject ReadBody<TObject>() where TObject : class
        {
            ReadStringContent();
            return Request.Serializer.Deserialize<TObject>(content);
        }

        /// <inheritdoc />
        public string ReadBody()
        {
            ReadStringContent();
            return content;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            if (disposed)
            {
                return;
            }

            disposed = true;

            if (Body != null)
            {
                Body.Dispose();
            }
        }

        private void ReadStringContent()
        {
            if (content != null)
            {
                return;
            }

            Body.Position = 0;
            StreamReader streamReader = new StreamReader(Body);
            content = streamReader.ReadToEnd();
        }
    }
}
