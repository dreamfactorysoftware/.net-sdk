namespace DreamFactory.Demo
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using DreamFactory.Http;

    public static class HttpDemo
    {
        public static async Task Run()
        {
            /*
             * Get random bytes as hex string from random.org
             */

            string url = "https://www.random.org/cgi-bin/randbyte?nbytes=16&format=h";
            IHttpRequest request = new HttpRequest(HttpMethod.Get, url, new HttpHeaders("Accept", "text/plain"));
            IHttpFacade httpFacade = new UnirestHttpFacade();

            Console.WriteLine("Sending GET request: {0}", url);
            IHttpResponse response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response);

            Console.WriteLine("Response CODE = {0}, BODY = {1}", response.Code, response.ReadAsString());

            /*
             * Get random bytes as binary file from random.org
             */

            url = "https://www.random.org/cgi-bin/randbyte?nbytes=16&format=f";
            request = new HttpRequest(HttpMethod.Get, url, new HttpHeaders("Accept", "application/octet-stream"));

            Console.WriteLine("Sending GET request: {0}", url);
            response = await httpFacade.SendAsync(request);
            HttpUtils.ThrowOnBadStatus(response);

            Console.WriteLine("Response CODE = {0}, received {1} bytes.", response.Code, response.Body.Length);
            using (BinaryReader reader = new BinaryReader(response.Body))
            {
                byte[] bytes = reader.ReadBytes((int)response.Body.Length);
                Console.WriteLine("BYTES: {0}", BitConverter.ToString(bytes).Replace('-', ' '));
                Console.WriteLine();
            }
        }
    }
}
