namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.Email;
    using DreamFactory.Serialization;

    internal class EmailApi : BaseApi, IEmailApi
    {
        public EmailApi(IHttpAddress baseAddress, IHttpFacade httpFacade, IContentSerializer contentSerializer, HttpHeaders baseHeaders, string serviceName)
            : base(baseAddress, httpFacade, contentSerializer, baseHeaders, serviceName)
        {
        }

        public async Task<int> SendEmailAsync(EmailRequest emailRequest)
        {
            if (emailRequest == null)
            {
                throw new ArgumentNullException("emailRequest");
            }

            EmailResponse response = await RequestSingleWithPayloadAsync<EmailRequest, EmailResponse>(HttpMethod.Post, new string[] {}, new SqlQuery(), emailRequest);
            return response.Count ?? 0;
        }
    }
}