namespace DreamFactory.Model.Database
{
    using global::System.Collections.Generic;

    /// <summary>
    /// Field schema.
    /// </summary>
    public class FieldSchema
    {
        /// <summary>
        /// The API name of the field.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// The displayable label for the field.
        /// </summary>
        public string label { get; set; }

        /// <summary>
        /// The DSP abstract data type for this field.
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// The native database type used for this field.
        /// </summary>
        public string db_type { get; set; }

        /// <summary>
        /// The maximum length allowed (in characters for string, displayed for numbers).
        /// </summary>
        public int? length { get; set; }

        /// <summary>
        /// Total number of places for numbers.
        /// </summary>
        public int? precision { get; set; }

        /// <summary>
        /// Number of decimal places allowed for numbers.
        /// </summary>
        public int? scale { get; set; }

        /// <summary>
        /// Default value for this field.
        /// </summary>
        public string default_value { get; set; }

        /// <summary>
        /// Is a value required for record creation.
        /// </summary>
        public bool? required { get; set; }

        /// <summary>
        /// Is null allowed as a value.
        /// </summary>
        public bool? allow_null { get; set; }

        /// <summary>
        /// Is the length fixed (not variable).
        /// </summary>
        public bool? fixed_length { get; set; }

        /// <summary>
        /// Does the data type support multibyte characters.
        /// </summary>
        public bool? supports_multibyte { get; set; }

        /// <summary>
        /// Does the integer field value increment upon new record creation.
        /// </summary>
        public bool? auto_increment { get; set; }

        /// <summary>
        /// Is this field used as/part of the primary key.
        /// </summary>
        public bool? is_primary_key { get; set; }

        /// <summary>
        /// Is this field used as a foreign key.
        /// </summary>
        public bool? is_foreign_key { get; set; }

        /// <summary>
        /// For foreign keys, the referenced table name.
        /// </summary>
        public string ref_table { get; set; }

        /// <summary>
        /// For foreign keys, the referenced table field name.
        /// </summary>
        public string ref_fields { get; set; }

        /// <summary>
        /// Validations to be performed on this field.
        /// </summary>
        public List<string> validation { get; set; }

        /// <summary>
        /// Selectable string values for client menus and picklist validation.
        /// </summary>
        public List<string> value { get; set; }
    }
}
