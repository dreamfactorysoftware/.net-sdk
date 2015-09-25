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
        public Task<IEnumerable<string>> GetStoredProcNamesAsync(bool refresh)
        {
            return GetNamesOnlyAsync("_proc", refresh);
        }

        public Task CallStoredProcAsync(string procedureName, params StoredProcParam[] parameters)
        {
            if (procedureName == null)
            {
                throw new ArgumentNullException("procedureName");
            }

            return CallStoredProc("_proc", procedureName, null, parameters);
        }

        public Task<TStoredProcResponse> CallStoredProcAsync<TStoredProcResponse>(string procedureName, params StoredProcParam[] parameters)
            where TStoredProcResponse : class, new()
        {
            if (procedureName == null)
            {
                throw new ArgumentNullException("procedureName");
            }

            return CallStoredProc<TStoredProcResponse>("_proc", procedureName, null, parameters);
        }

        public Task<TStoredProcResponse> CallStoredProcAsync<TStoredProcResponse>(string procedureName, string wrapper, params StoredProcParam[] parameters)
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

            return CallStoredProc<TStoredProcResponse>("_proc", procedureName, wrapper, parameters);
        }

        public Task<IEnumerable<string>> GetStoredFuncNamesAsync(bool refresh)
        {
            return GetNamesOnlyAsync("_func", refresh);
        }

        public Task<TStoredFuncResponse> CallStoredFuncAsync<TStoredFuncResponse>(string functionName, params StoredProcParam[] parameters)
            where TStoredFuncResponse : class, new()
        {
            if (functionName == null)
            {
                throw new ArgumentNullException("functionName");
            }

            return CallStoredProc<TStoredFuncResponse>("_func", functionName, null, parameters);
        }

        public Task<TStoredFuncResponse> CallStoredFuncAsync<TStoredFuncResponse>(string functionName, string wrapper, params StoredProcParam[] parameters)
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

            return CallStoredProc<TStoredFuncResponse>("_func", functionName, wrapper, parameters);
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

        private Task<string> CallStoredProc(string resource, string procedureName, string wrapper, params StoredProcParam[] parameters)
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

            return ExecuteRequest(request);
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
