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
        public string Message { get; set; }

        /// <summary>
        /// Gets HTTP status code.
        /// </summary>
        public int Code { get; set; }
    }
}
