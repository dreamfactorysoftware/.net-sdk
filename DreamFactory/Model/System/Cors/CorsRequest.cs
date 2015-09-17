namespace DreamFactory.Model.System.Cors
{
    /// <summary>
    /// CORS request.
    /// </summary>
    public class CorsRequest : IRecord
    {
        /// <summary>
        /// Identifier of the record.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Path of the CORS.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Origin of the CORS.
        /// </summary>
        public string Origin { get; set; }

        /// <summary>
        /// Header of the CORS.
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// HTTP methods allowed.
        /// </summary>
        public int? Method { get; set; }

        /// <summary>
        /// Max age.
        /// </summary>
        public int? MaxAge { get; set; }

        /// <summary>
        /// Indicates whether it is enabled.
        /// </summary>
        public bool Enabled { get; set; }
    }
}
