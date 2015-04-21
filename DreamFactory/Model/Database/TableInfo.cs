// ReSharper disable InconsistentNaming
namespace DreamFactory.Model.Database
{
    using System.Collections.Generic;

    /// <summary>
    /// A table information.
    /// </summary>
    public class TableInfo
    {
        /// <summary>
        /// Identifier/Name for the table.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Displayable singular name for the table.
        /// </summary>
        public string label { get; set; }

        /// <summary>
        /// Displayable plural name for the table.
        /// </summary>
        public string plural { get; set; }

        /// <summary>
        /// List of allowed HTTP verbs.
        /// </summary>
        public List<string> access { get; set; } 
    }
}
