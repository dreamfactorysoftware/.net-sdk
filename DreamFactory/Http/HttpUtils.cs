namespace DreamFactory.Http
{
    using System;
    using System.Linq;
    using DreamFactory.Model;
    using DreamFactory.Serialization;

    /// <summary>
    /// Utility methods for testing HTTP status code.
    /// </summary>
    public static class HttpUtils
    {
        /// <summary>
        /// Throws DreamFactoryException on bad HTTP status code. 
        /// </summary>
        /// <param name="response"><see cref="IHttpResponse"/> instance.</param>
        /// <param name="serializer">Serializer instance.</param>
        public static void ThrowOnBadStatus(IHttpResponse response, IObjectSerializer serializer)
        {
            if (response == null)
            {
                throw new ArgumentNullException("response");
            }

            if (serializer == null)
            {
                throw new ArgumentNullException("serializer");
            }

            string message;

            switch (response.Code)
            {
                case 400:
                    message = "400: Bad Request - Request does not have a valid format, all required parameters, etc.";
                    break;

                case 401:
                    message = "401 - The login information did not match any records on the backend.";
                    break;

                case 403:
                    message = "403 - CORS has not been enabled and you’re trying to use the API cross-domain.";
                    break;

                case 404:
                    message = "404 - The requested DSP is not found.";
                    break;

                case 500:
                    message = "500 - Internal server error";
                    break;

                default:
                    return;
            }

            message = TryGetErrorMessage(response, serializer, message);

            DreamFactoryException exception = new DreamFactoryException(message);
            exception.Data.Add("Method", response.Request.Method);
            exception.Data.Add("URL", response.Request.Url);
            throw exception;
        }

        /// <summary>
        /// Gets HTTP method string.
        /// </summary>
        /// <param name="method">HTTP method enumeration.</param>
        /// <returns>HTTP method string.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string GetHttpMethodName(HttpMethod method)
        {
            switch (method)
            {
                case HttpMethod.Get:
                    return "GET";

                case HttpMethod.Post:
                    return "POST";

                case HttpMethod.Put:
                    return "PUT";

                case HttpMethod.Patch:
                    return "PATCH";

                case HttpMethod.Delete:
                    return "DELETE";

                default:
                    throw new ArgumentOutOfRangeException("method");
            }
        }

        /// <summary>
        /// Checks given URL string.
        /// </summary>
        /// <param name="url">A URL string.</param>
        /// <exception cref="ArgumentException"></exception>
        public static void CheckUrlString(string url)
        {
            Uri uri;
            if (Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out uri))
            {
                bool hasValidSchema = uri.Scheme == "http" || uri.Scheme == "https";

                if (uri.IsAbsoluteUri && hasValidSchema)
                {
                    return;
                }
            }

            throw new ArgumentException("The url string is not a valid HTTP/S URL.");
        }

        private static string TryGetErrorMessage(IHttpResponse response, IObjectSerializer serializer, string @default)
        {
            try
            {
                string message = @default;
                ErrorModel errorModel = serializer.Deserialize<ErrorModel>(response.Body);
                if (errorModel.error != null)
                {
                    message = errorModel.error.First().message;
                }

                return string.Format("{0} - {1}", response.Code, message);
            }
            catch (Exception)
            {
                return @default;
            }
        }
    }
}
