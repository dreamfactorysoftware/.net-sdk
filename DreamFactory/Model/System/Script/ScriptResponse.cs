// ReSharper disable InconsistentNaming
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
        public string script_id { get; set; }

        /// <summary>
        /// The body of the script.
        /// </summary>
        public string script_body { get; set; }

        /// <summary>
        /// The script file name.
        /// </summary>
        public string script { get; set; }

        /// <summary>
        /// True if this is a user script.
        /// </summary>
        public bool? is_user_script { get; set; }

        /// <summary>
        /// The scripting language. Only "js" is supported at this time.
        /// </summary>
        public string language { get; set; }

        /// <summary>
        /// The script file name.
        /// </summary>
        public string file_name { get; set; }

        /// <summary>
        /// The path where the script file lives.
        /// </summary>
        public string file_path { get; set; }

        /// <summary>
        /// The last modified time of the file in UNIX time.
        /// </summary>
        public long? file_mtime { get; set; }

        /// <summary>
        /// The name of the event this script is fired on or FALSE if none.
        /// </summary>
        public string event_name { get; set; }

        /// <summary>
        /// The creation date and time of the record.
        /// </summary>
        public DateTime? created_date { get; set; }

        /// <summary>
        /// The ID of the user that created this record.
        /// </summary>
        public int? created_by_id { get; set; }

        /// <summary>
        /// The date and time of this record's last modification.
        /// </summary>
        public DateTime? last_modified_date { get; set; }

        /// <summary>
        /// The ID of the user that last modified this record.
        /// </summary>
        public int? last_modified_by_id { get; set; }
    }
}
