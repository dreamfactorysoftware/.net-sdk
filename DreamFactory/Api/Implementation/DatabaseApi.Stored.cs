namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.Database;

    internal partial class DatabaseApi
    {
        public async Task<IEnumerable<string>> GetStoredProcNamesAsync(bool refresh)
        {
            return await GetNamesOnlyAsync("_proc", refresh);
        }

        public async Task CallStoredProcAsync(string procedureName, params StoredProcParam[] parameters)
        {
            if (procedureName == null)
            {
                throw new ArgumentNullException("procedureName");
            }

            await CallStoredProc("_proc", procedureName, null, parameters);
        }

        public async Task<TStoredProcResponse> CallStoredProcAsync<TStoredProcResponse>(string procedureName, params StoredProcParam[] parameters)
            where TStoredProcResponse : class, new()
        {
            if (procedureName == null)
            {
                throw new ArgumentNullException("procedureName");
            }

            IHttpResponse response = await CallStoredProc("_proc", procedureName, null, parameters);

            return contentSerializer.Deserialize<TStoredProcResponse>(response.Body);
        }

        public async Task<TStoredProcResponse> CallStoredProcAsync<TStoredProcResponse>(string procedureName, string wrapper, params StoredProcParam[] parameters)
            where TStoredProcResponse : class, new()
        {
            if (procedureName == null)
            {
                throw new ArgumentNullException("procedureName");
            }

            if (wrapper == null)
            {
                throw new ArgumentNullException("wrapper");
            }

            IHttpResponse response = await CallStoredProc("_proc", procedureName, wrapper, parameters);

            return contentSerializer.Deserialize<TStoredProcResponse>(response.Body);
        }

        public async Task<IEnumerable<string>> GetStoredFuncNamesAsync(bool refresh)
        {
            return await GetNamesOnlyAsync("_func", refresh);
        }

        public async Task<TStoredFuncResponse> CallStoredFuncAsync<TStoredFuncResponse>(string functionName, params StoredProcParam[] parameters)
            where TStoredFuncResponse : class, new()
        {
            if (functionName == null)
            {
                throw new ArgumentNullException("functionName");
            }

            IHttpResponse response = await CallStoredProc("_func", functionName, null, parameters);

            return contentSerializer.Deserialize<TStoredFuncResponse>(response.Body);
        }

        public async Task<TStoredFuncResponse> CallStoredFuncAsync<TStoredFuncResponse>(string functionName, string wrapper, params StoredProcParam[] parameters)
            where TStoredFuncResponse : class, new()
        {
            if (functionName == null)
            {
                throw new ArgumentNullException("functionName");
            }

            if (wrapper == null)
            {
                throw new ArgumentNullException("wrapper");
            }

            IHttpResponse response = await CallStoredProc("_func", functionName, wrapper, parameters);

            return contentSerializer.Deserialize<TStoredFuncResponse>(response.Body);
        }

        private async Task<IEnumerable<string>> GetNamesOnlyAsync(string resource, bool refresh)
        {
            IHttpAddress address = baseAddress.WithResource( resource).WithParameter("names_only", true);

            if (refresh)
            {
                address = address.WithParameter("refresh", true);
            }

            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var result = new { resource = new List<string>() };
            return contentSerializer.Deserialize(response.Body, result).resource;
        }

        private async Task<IHttpResponse> CallStoredProc(string resource, string procedureName, string wrapper, params StoredProcParam[] parameters)
        {
            IHttpAddress address = baseAddress.WithResource( resource, procedureName);

            if (!string.IsNullOrEmpty(wrapper))
            {
                address = address.WithParameter("wrapper", wrapper);
            }

            IHttpRequest request;

            if (parameters.Length > 0)
            {
                StoredProcRequest storedProc = new StoredProcRequest
                {
                    Params = parameters.ToList(),
                    Wrapper = wrapper
                };
                string body = contentSerializer.Serialize(storedProc);
                request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, body);
            }
            else
            {
                request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);
            }

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return response;
        }
    }
}
