namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.System.Script;

    internal partial class SystemApi
    {
        public async Task<IEnumerable<ScriptResponse>> GetScriptsAsync(bool includeUserScripts)
        {
            IHttpAddress address = baseAddress.WithResources(SystemService, "script")
                                              .WithParameter("include_script_body", true)
                                              .WithParameter("include_user_scripts", includeUserScripts);

            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var scripts = new { resource = new List<ScriptResponse>() };
            return contentSerializer.Deserialize(response.Body, scripts).resource;
        }

        public async Task<ScriptResponse> WriteScriptAsync(string id, string body, bool userScript)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            if (body == null)
            {
                throw new ArgumentNullException("body");
            }

            IHttpAddress address = baseAddress.WithResources(SystemService, "script", id);
            if (userScript)
            {
                address = address.WithParameter("is_user_script", true);
            }

            IHttpRequest request = new HttpRequest(HttpMethod.Put, address.Build(), baseHeaders, body);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<ScriptResponse>(response.Body);
        }

        public async Task<ScriptOutput> RunScriptAsync(string id, bool userScript, bool logOutput)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            IHttpAddress address = baseAddress.WithResources(SystemService, "script", id)
                                              .WithParameter("log_output", logOutput);
            if (userScript)
            {
                address = address.WithParameter("is_user_script", true);
            }

            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, string.Empty);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<ScriptOutput>(response.Body);
        }

        public async Task DeleteScriptAsync(string id, bool userScript)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            IHttpAddress address = baseAddress.WithResources(SystemService, "script", id);
            if (userScript)
            {
                address = address.WithParameter("is_user_script", true);
            }

            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);
        }
    }
}
