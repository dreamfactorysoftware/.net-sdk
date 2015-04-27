// ReSharper disable InconsistentNaming
namespace DreamFactory.Model.Database
{
    using global::System.Collections.Generic;

    /// <summary>
    /// Stored procedure request.
    /// </summary>
    public class StoredProcRequest
    {
        /// <summary>
        /// Optional array of input and output parameters.
        /// </summary>
        public List<StoredProcParam> @params { get; set; }

        /// <summary>
        /// Add this wrapper around the expected data set before returning, same as URL parameter.
        /// </summary>
        public string wrapper { get; set; }
    }
}
