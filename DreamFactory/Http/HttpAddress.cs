namespace DreamFactory.Http
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DreamFactory.Rest;

    internal class HttpAddress
    {
        private readonly string baseAddress;

        private readonly RestApiVersion version;

        private readonly List<string> resources;

        private readonly Dictionary<string, object> parameters;

        public HttpAddress(string baseAddress, RestApiVersion version, List<string> resources, Dictionary<string, object> parameters)
        {
            this.baseAddress = baseAddress;
            this.version = version;
            this.resources = resources;
            this.parameters = parameters;
        }

        public HttpAddress WithBaseAddress(string value)
        {
            return new HttpAddress(value, version, resources, parameters);
        }

        public HttpAddress WithVersion(RestApiVersion value)
        {
            return new HttpAddress(baseAddress, value, resources, parameters);
        }

        public HttpAddress WithResources(params string[] values)
        {
            return new HttpAddress(baseAddress, version, values.ToList(), parameters);
        }

        public HttpAddress WithParameter(string name, object value)
        {
            Dictionary<string, object> temp = new Dictionary<string, object>(parameters) { { name, value } };

            return new HttpAddress(baseAddress, version, resources, temp);
        }

        public string Build()
        {
            string address = baseAddress.EndsWith("/") ? baseAddress : baseAddress + '/';

            switch (version)
            {
                case RestApiVersion.V1:
                    address += "rest/";
                    break;

                case RestApiVersion.V2:
                    address += "api/v2.0/";
                    break;

                default:
                    throw new NotSupportedException("REST API version " + version + " is not supported");
            }

            address = string.Format("{0}{1}", address, string.Join("/", resources));

            if (parameters.Count <= 0)
            {
                return address;
            }

            string temp = string.Join("&", parameters.Select(x => string.Format("{0}={1}", x.Key, x.Value)));
            return string.Format("{0}?{1}", address, temp);
        }
    }
}
