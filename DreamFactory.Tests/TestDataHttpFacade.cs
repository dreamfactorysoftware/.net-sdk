namespace DreamFactory.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Serialization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    internal class TestDataHttpFacade : IHttpFacade
    {
        private readonly IContentSerializer serializer;

        private readonly string testDataPath;

        private readonly string suffix;

        public TestDataHttpFacade(string suffix = null)
        {
            this.suffix = suffix;
            serializer = new JsonContentSerializer();

            Uri location = new Uri(Assembly.GetExecutingAssembly().CodeBase);
            testDataPath = Path.GetDirectoryName(location.AbsolutePath) ?? Environment.CurrentDirectory;
            testDataPath = Path.Combine(testDataPath, "TestData");

            if (!Directory.Exists(testDataPath))
            {
                Assert.Fail("TestData directory does not exist, please check the solution");
            }
        }

        public Task<IHttpResponse> SendAsync(IHttpRequest request)
        {
            IHttpResponse response;

            // Test headers
            Dictionary<string, object> headers = request.Headers.Build();
            string method = HttpUtils.GetHttpMethodName(request.Method).ToLowerInvariant();
            if (headers.ContainsKey(HttpHeaders.TunnelingHeader))
            {
                method = headers[HttpHeaders.TunnelingHeader].ToString().ToLowerInvariant();
            }

            // Build request and response files lookup
            string[] parts = new Uri(request.Url).LocalPath.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            string resourcePath = Path.Combine(testDataPath, string.Join("\\", parts));
            if (suffix != null)
            {
                resourcePath = resourcePath + "-" + suffix;
            }
            string responseFile = Path.Combine(resourcePath, method + ".json");
            string requestFile = Path.Combine(resourcePath, method + ".request.json");

            // Check the request data if present
            if (File.Exists(requestFile))
            {
                string content = File.ReadAllText(requestFile);
                if (string.Compare(request.Body, content, StringComparison.InvariantCultureIgnoreCase) != 0)
                {
                    string error = CreateErrorResponse(400, string.Format("Content mismatch:\nExpected={0}\nReceived={1}", content, request.Body));
                    response = new HttpResponse(request, 400, error);
                    return Task.FromResult(response);
                }
            }

            // Build response if possible
            try
            {
                string content = File.ReadAllText(responseFile);
                response = new HttpResponse(request, 200, content);
            }
            catch (FileNotFoundException ex)
            {
                string error = CreateErrorResponse(404, ex.Message);
                response = new HttpResponse(request, 404, error);
            }
            catch (Exception ex)
            {
                string error = CreateErrorResponse(500, ex.Message);
                response = new HttpResponse(request, 500, error);
            }

            return Task.FromResult(response);
        }

        private string CreateErrorResponse(int code, string message)
        {
            Error errorData = new Error { code = code, message = message };
            var error = new { error = new List<Error> { errorData } };
            return serializer.Serialize(error);
        }
    }
}
