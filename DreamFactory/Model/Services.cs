// ReSharper disable InconsistentNaming
namespace DreamFactory.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// getServices() response.
    /// </summary>
    public class Services
    {
        /// <summary>
        /// Gets collection of services.
        /// </summary>
        public List<Service> service { get; set; }
    }

    /// <summary>
    /// A Service descriptor.
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Gets service's name.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Gets service's API name.
        /// </summary>
        public string api_name { get; set; }
    }
}
