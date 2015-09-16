namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model;
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

            return await CallStoredProc<TStoredProcResponse>("_proc", procedureName, null, parameters);
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

            return await CallStoredProc<TStoredProcResponse>("_proc", procedureName, wrapper, parameters);
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

            return await CallStoredProc<TStoredFuncResponse>("_func", functionName, null, parameters);
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

            return await CallStoredProc<TStoredFuncResponse>("_func", functionName, wrapper, parameters);
        }

        #region private methods

        private async Task<IEnumerable<string>> GetNamesOnlyAsync(string resource, bool refresh)
        {
            SqlQuery query = new SqlQuery
            {
                Fields = null,
                CustomParameters = new Dictionary<string, object>
                {
                    { "names_only", true },
                    { "refresh", refresh }
                }
            };

            ResourceWrapper<string> result = await RequestAsync<ResourceWrapper<string>>(HttpMethod.Get, resource, query);

            return result.Records;
        }

        private async Task<string> CallStoredProc(string resource, string procedureName, string wrapper, params StoredProcParam[] parameters)
        {
            SqlQuery query = null;
            if (!string.IsNullOrEmpty(wrapper))
            {
                query = new SqlQuery
                {
                    Fields = null,
                    CustomParameters = new Dictionary<string, object> { { "wrapper", wrapper } }
                };
            }

            IHttpRequest request;

            if (parameters.Length > 0)
            {
                StoredProcRequest storedProc = new StoredProcRequest
                {
                    Params = parameters.ToList(),
                    Wrapper = wrapper
                };
                string body = base.ContentSerializer.Serialize(storedProc);
                request = base.BuildRequest(HttpMethod.Post, body, new[] { resource, procedureName }, query);
            }
            else
            {
                request = base.BuildRequest(HttpMethod.Get, null, new[] { resource, procedureName }, query);
            }

            return await ExecuteRequest(request);
        }

        private async Task<TStoredProcResponse> CallStoredProc<TStoredProcResponse>(string resource, string procedureName, string wrapper, params StoredProcParam[] parameters)
            where TStoredProcResponse : class, new()
        {
            string responseBody = await CallStoredProc(resource, procedureName, wrapper, parameters);

            return base.ContentSerializer.Deserialize<TStoredProcResponse>(responseBody);
        }

        #endregion
    }
}
