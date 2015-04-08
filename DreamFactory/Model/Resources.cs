// ReSharper disable InconsistentNaming
namespace DreamFactory.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// Resources.
    /// </summary>
    public class Resources
    {
        /// <summary>
        /// Array of resources available by this service.
        /// </summary>
        public List<Resource> resource { get; set; }
    }

    /// <summary>
    /// Resource.
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// Name of the resource.
        /// </summary>
        public string name { get; set; }
    }
}
