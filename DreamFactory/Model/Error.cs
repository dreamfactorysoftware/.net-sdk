// ReSharper disable InconsistentNaming
namespace DreamFactory.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// Error response.
    /// </summary>
    public class ErrorModel
    {
        /// <summary>
        /// Gets errors.
        /// </summary>
        public List<Error> error{ get; set; }
    }

    /// <summary>
    /// Error data.
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Gets error message.
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// Gets HTTP status code.
        /// </summary>
        public int code { get; set; }
    }
}
