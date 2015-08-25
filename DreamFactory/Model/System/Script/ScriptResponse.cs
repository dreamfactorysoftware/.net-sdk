namespace DreamFactory.Model.System.Script
{
    using global::System;

    /// <summary>
    /// ScriptResponse.
    /// </summary>
    public class ScriptResponse
    {
        /// <summary>
        /// The script ID.
        /// </summary>
        public string ScriptId { get; set; }

        /// <summary>
        /// The body of the script.
        /// </summary>
        public string ScriptBody { get; set; }

        /// <summary>
        /// The script file name.
        /// </summary>
        public string Script { get; set; }

        /// <summary>
        /// True if this is a user script.
        /// </summary>
        public bool? IsUserScript { get; set; }

        /// <summary>
        /// The scripting language. Only "js" is supported at this time.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// The script file name.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The path where the script file lives.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// The last modified time of the file in UNIX time.
        /// </summary>
        public long? FileMtime { get; set; }

        /// <summary>
        /// The name of the event this script is fired on or FALSE if none.
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// The creation date and time of the record.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// The ID of the user that created this record.
        /// </summary>
        public int? CreatedById { get; set; }

        /// <summary>
        /// The date and time of this record's last modification.
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// The ID of the user that last modified this record.
        /// </summary>
        public int? LastModifiedById { get; set; }
    }
}
