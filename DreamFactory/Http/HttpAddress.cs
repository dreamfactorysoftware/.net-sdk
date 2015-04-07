namespace DreamFactory.Http
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DreamFactory.Rest;

    internal class HttpAddress
    {
        private readonly Dictionary<string, string> queryParams;

        private readonly List<string> resources;

        private readonly string address;

        public HttpAddress(string baseAddress, RestApiVersion version)
        {
            if (!baseAddress.EndsWith("/"))
            {
                baseAddress += '/';
            }

            address = baseAddress;
            queryParams = new Dictionary<string, string>();
            resources = new List<string>();

            switch (version)
            {
                case RestApiVersion.V1:
                    resources.Add("rest");
                    break;

                case RestApiVersion.V2:
                    resources.Add("api");
                    resources.Add("v2.0");
                    break;

                default:
                    throw new NotSupportedException("REST API version " + version + " is not supported");
            }
        }

        public void AddPath(params string[] args)
        {
            foreach (string resource in args)
            {
                resources.Add(resource);
            }
        }

        public void AddParameter(string name, object value)
        {
            queryParams[name] = value.ToString();
        }

        public override string ToString()
        {
            string temp = string.Format("{0}{1}", address, string.Join("/", resources));

            if (queryParams.Count > 0)
            {
                string parameters = string.Join("&", queryParams.Select(x => string.Format("{0}={1}", x.Key, x.Value)));
                temp = string.Format("{0}?{1}", temp, parameters);
            }

            return temp;
        }
    }
}