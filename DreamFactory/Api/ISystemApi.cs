namespace DreamFactory.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Model.System;

    /// <summary>
    /// Represents /system API.
    /// </summary>
    public interface ISystemApi
    {
        /// <summary>
        /// Retrieve one or more applications.
        /// </summary>
        /// <returns>Sequence of AppResponse.</returns>
        Task<IEnumerable<AppResponse>> GetAppsAsync();
    }
}
