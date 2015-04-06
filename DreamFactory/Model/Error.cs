// ReSharper disable InconsistentNaming
namespace DreamFactory.Model
{
    /// <summary>
    /// Error response.
    /// </summary>
    public class Error : IModel
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
