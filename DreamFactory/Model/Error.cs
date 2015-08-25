namespace DreamFactory.Model
{
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
