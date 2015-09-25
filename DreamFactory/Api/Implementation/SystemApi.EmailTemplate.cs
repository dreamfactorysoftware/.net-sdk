namespace DreamFactory.Api.Implementation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.Email;

    internal partial class SystemApi
    {
        public async Task<IEnumerable<EmailTemplateResponse>> GetEmailTemplatesAsync(SqlQuery query)
        {
            ResourceWrapper<EmailTemplateResponse> response = await base.RequestAsync<ResourceWrapper<EmailTemplateResponse>>(
                method: HttpMethod.Get,
                resource: "email_template",
                query: query
                );

            return response.Records;
        }


        public Task<IEnumerable<EmailTemplateResponse>> CreateEmailTemplatesAsync(SqlQuery query, params EmailTemplateRequest[] templates)
        {
            return base.RequestWithPayloadAsync<EmailTemplateRequest, EmailTemplateResponse>(
                method: HttpMethod.Post,
                resource: "email_template",
                query: query,
                payload: templates
                );
        }

        public Task<IEnumerable<EmailTemplateResponse>> UpdateEmailTemplatesAsync(SqlQuery query, params EmailTemplateRequest[] templates)
        {
            return base.RequestWithPayloadAsync<EmailTemplateRequest, EmailTemplateResponse>(
                method: HttpMethod.Patch,
                resource: "email_template",
                query: query,
                payload: templates
                );
        }

        public Task<IEnumerable<EmailTemplateResponse>> DeleteEmailTemplatesAsync(SqlQuery query, params int[] ids)
        {
            return base.RequestDeleteAsync<EmailTemplateResponse>(
                resource: "email_template",
                query: query,
                force: false,
                ids: ids
                );
        }
    }
}
