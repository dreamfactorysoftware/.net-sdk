namespace DreamFactory.Http
{
    using System;
    using System.IO;
    using DreamFactory.Model;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents generic HTTP response.
    /// </summary>
    public class HttpResponse : IHttpResponse
    {
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
        public TModel ReadAsJson<TModel>()
            where TModel : class, IModel
        {
            string json = ReadAsString();
            return JsonConvert.DeserializeObject<TModel>(json);
        }

        /// <inheritdoc />
        public string ReadAsString()
        {
            Body.Position = 0;
            StreamReader streamReader = new StreamReader(Body);
            return streamReader.ReadToEnd();
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
    }
}