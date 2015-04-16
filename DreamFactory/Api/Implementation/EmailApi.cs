namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Model.Email;
    using DreamFactory.Serialization;

    internal class EmailApi : IEmailApi
    {
        private readonly IHttpAddress baseAddress;
        private readonly IHttpFacade httpFacade;
        private readonly IContentSerializer contentSerializer;
        private readonly IHttpHeaders baseHeaders;

        public EmailApi(IHttpAddress baseAddress, IHttpFacade httpFacade, IContentSerializer contentSerializer, IHttpHeaders baseHeaders, string serviceName)
        {
            this.baseAddress = baseAddress.WithResources(serviceName);
            this.httpFacade = httpFacade;
            this.contentSerializer = contentSerializer;
            this.baseHeaders = baseHeaders;
        }

        public async Task<int> SendEmailAsync(EmailRequest emailRequest)
        {
            if (emailRequest == null)
            {
                throw new ArgumentNullException("emailRequest");
            }

            string content = contentSerializer.Serialize(emailRequest);
            IHttpRequest request = new HttpRequest(HttpMethod.Post, baseAddress.Build(), baseHeaders, content);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var emailsSent = new { count = 0 };
            return contentSerializer.Deserialize(response.Body, emailsSent).count;
        }
    }
}