namespace DreamFactory.Demo.Demo
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Rest;

    public static class HttpDemo
    {
        public static async Task Run(IRestContext context)
        {
            /*
             * Get random bytes as hex string from random.org
             */

            const string url = "https://www.random.org/cgi-bin/randbyte?nbytes=16&format=h";
            IHttpRequest request = new HttpRequest(HttpMethod.Get, url, new HttpHeaders());
            IHttpFacade httpFacade = new UnirestHttpFacade();

            Console.WriteLine("Sending GET request: {0}", url);
            IHttpResponse response = await httpFacade.RequestAsync(request);

            Console.WriteLine("Response CODE = {0}, BODY = {1}", response.Code, response.Body.Trim());
        }
    }
}
