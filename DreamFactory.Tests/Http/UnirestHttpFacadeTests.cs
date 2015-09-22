namespace DreamFactory.Tests.Http
{
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Shouldly;

    [TestClass]
    public class UnirestHttpFacadeTests
    {
        // If this port is busy on your machine, assign another one
        private const string TestAddress = "http://localhost:8080/";

        [TestMethod]
        public void ShouldSendGetRequest()
        {
            // Arrange
            const string url = TestAddress + "a/b/c";
            ManualResetEventSlim stopServerEvent = StartWebServer(url, "GET");

            IHttpFacade httpFacade = new UnirestHttpFacade();
            IHttpRequest request = new HttpRequest(HttpMethod.Get, url, new HttpHeaders());

            // Act
            IHttpResponse response = httpFacade.RequestAsync(request).Result;

            // Assert
            response.Code.ShouldBe(200);

            stopServerEvent.Set();
        }

        [TestMethod]
        public void ShouldSendPostRequest()
        {
            // Arrange
            const string url = TestAddress + "a/b/c";
            ManualResetEventSlim stopServerEvent = StartWebServer(url, "POST");

            IHttpFacade httpFacade = new UnirestHttpFacade();
            IHttpRequest request = new HttpRequest(HttpMethod.Post, url, new HttpHeaders(), "body");

            // Act
            IHttpResponse response = httpFacade.RequestAsync(request).Result;

            // Assert
            response.Code.ShouldBe(200);
            response.Body.ShouldContain("body");

            stopServerEvent.Set();
        }

        [TestMethod]
        public void ShouldSendPutRequest()
        {
            // Arrange
            const string url = TestAddress + "a/b/c";
            ManualResetEventSlim stopServerEvent = StartWebServer(url, "PUT");

            IHttpFacade httpFacade = new UnirestHttpFacade();
            IHttpRequest request = new HttpRequest(HttpMethod.Put, url, new HttpHeaders(), "body");

            // Act
            IHttpResponse response = httpFacade.RequestAsync(request).Result;

            // Assert
            response.Code.ShouldBe(200);
            response.Body.ShouldContain("body");

            stopServerEvent.Set();
        }

        [TestMethod]
        public void ShouldSendPatchRequest()
        {
            // Arrange
            const string url = TestAddress + "a/b/c";
            ManualResetEventSlim stopServerEvent = StartWebServer(url, "PATCH");

            IHttpFacade httpFacade = new UnirestHttpFacade();
            IHttpRequest request = new HttpRequest(HttpMethod.Patch, url, new HttpHeaders(), "body");

            // Act
            IHttpResponse response = httpFacade.RequestAsync(request).Result;

            // Assert
            response.Code.ShouldBe(200);
            response.Body.ShouldContain("body");

            stopServerEvent.Set();
        }

        [TestMethod]
        public void ShouldSendDeleteRequest()
        {
            // Arrange
            const string url = TestAddress + "a/b/c";
            ManualResetEventSlim stopServerEvent = StartWebServer(url, "DELETE");

            IHttpFacade httpFacade = new UnirestHttpFacade();
            IHttpRequest request = new HttpRequest(HttpMethod.Delete, url, new HttpHeaders());

            // Act
            IHttpResponse response = httpFacade.RequestAsync(request).Result;

            // Assert
            response.Code.ShouldBe(200);
            response.Body.ShouldNotBe(null);

            stopServerEvent.Set();
        }

        private static ManualResetEventSlim StartWebServer(string url, string method)
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(TestAddress);

            ManualResetEventSlim canStopServer = new ManualResetEventSlim(false);

            Task.Factory.StartNew(() => WebServerCore(url, method, listener, canStopServer), TaskCreationOptions.LongRunning);

            return canStopServer;
        }

        private static void WebServerCore(string url, string method, HttpListener listener, ManualResetEventSlim canStopServer)
        {
            listener.Start();

            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            response.StatusCode = (int)HttpStatusCode.OK;

            if (request.Url.ToString() != url)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            if (request.HttpMethod != method)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            request.InputStream.CopyTo(response.OutputStream);
            response.Close();

            canStopServer.Wait();
            listener.Stop();
        }
    }
}
