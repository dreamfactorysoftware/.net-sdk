namespace DreamFactory.Model.Database
{
    using global::System.Collections.Generic;

    /// <summary>
    /// A table information.
    /// </summary>
    public class TableInfo
    {
        /// <summary>
        /// Identifier/Name for the table.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Displayable singular name for the table.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Displayable plural name for the table.
        /// </summary>
        public string Plural { get; set; }

        /// <summary>
        /// List of allowed HTTP verbs.
        /// </summary>
        public List<string> Access { get; set; } 
    }
}
