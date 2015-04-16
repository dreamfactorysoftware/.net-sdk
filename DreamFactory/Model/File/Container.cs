namespace DreamFactory.Model.File
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A storage container.
    /// </summary>
    public class Container
    {
        /// <summary>
        /// Identifier/Name for the container.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Same as name for the container, for consistency.
        /// </summary>
        public string path { get; set; }

        /// <summary>
        /// Date and time of last modification.
        /// </summary>
        public DateTime? last_modified { get; set; }

        /// <summary>
        /// List of allowed HTTP verbs.
        /// </summary>
        public List<string> access { get; set; } 
    }
}
