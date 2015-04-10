// ReSharper disable InconsistentNaming
namespace DreamFactory.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// Table's schema model.
    /// </summary>
    public class TableSchema
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
        /// Field(s), if any, that represent the primary key of each record.
        /// </summary>
        public string primary_key { get; set; }

        /// <summary>
        /// Field(s), if any, that represent the name of each record.
        /// </summary>
        public string name_field { get; set; }

        /// <summary>
        /// An array of available fields in each record.
        /// </summary>
        public List<FieldSchema> field { get; set; }

        /// <summary>
        /// An array of available relationships to other tables.
        /// </summary>
        public List<RelatedSchema> related { get; set; }
    }
}