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

        public async Task<ScriptResponse> WriteScriptAsync(string id, string body)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            if (body == null)
            {
                throw new ArgumentNullException("body");
            }

            IHttpAddress address = baseAddress
                .WithResources(SystemService, "script", id)
                .WithParameter("is_user_script", true);

            IHttpRequest request = new HttpRequest(HttpMethod.Put, address.Build(), baseHeaders.Exclude(HttpHeaders.ContentTypeHeader), body);
            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize<ScriptResponse>(response.Body);
        }

        public async Task<string> RunScriptAsync(string scriptId, bool logOutput)
        {
            if (scriptId == null)
            {
                throw new ArgumentNullException("scriptId");
            }

            return await RunAnyScriptAsync(scriptId, null, logOutput);
        }

        public async Task<string> RunScriptAsync(string scriptId, Dictionary<string, object> parameters, bool logOutput)
        {
            if (scriptId == null)
            {
                throw new ArgumentNullException("scriptId");
            }

            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            return await RunAnyScriptAsync(scriptId, parameters, logOutput);
        }

        public async Task DeleteScriptAsync(string scriptId)
        {
            if (scriptId == null)
            {
                throw new ArgumentNullException("scriptId");
            }

            IHttpAddress address = baseAddress
                .WithResources(SystemService, "script", scriptId)
                .WithParameter("is_user_script", true);

            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), baseHeaders);
            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);
        }

        private async Task<string> RunAnyScriptAsync(string scriptId, Dictionary<string, object> parameters, bool logOutput)
        {
            IHttpAddress address = baseAddress
                .WithResources(SystemService, "script", scriptId)
                .WithParameter("is_user_script", true)
                .WithParameter("log_output", logOutput);

            if (parameters != null)
            {
                foreach (KeyValuePair<string, object> pair in parameters)
                {
                    address = address.WithParameter(pair.Key, pair.Value.ToString().ToLowerInvariant());
                }
            }

            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, string.Empty);
            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var result = new { script_result = string.Empty };
            return contentSerializer.Deserialize(response.Body, result).script_result;
        }
    }
}
