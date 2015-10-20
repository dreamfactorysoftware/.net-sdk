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
        public string Name { get; set; }

        /// <summary>
        /// The displayable label for the field.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The DSP abstract data type for this field.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The native database type used for this field.
        /// </summary>
        public string DbType { get; set; }

        /// <summary>
        /// The maximum length allowed (in characters for string, displayed for numbers).
        /// </summary>
        public int? Length { get; set; }

        /// <summary>
        /// Total number of places for numbers.
        /// </summary>
        public int? Precision { get; set; }

        /// <summary>
        /// Number of decimal places allowed for numbers.
        /// </summary>
        public int? Scale { get; set; }

        /// <summary>
        /// Default value for this field.
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// Is a value required for record creation.
        /// </summary>
        public bool? Required { get; set; }

        /// <summary>
        /// Is null allowed as a value.
        /// </summary>
        public bool? AllowNull { get; set; }

        /// <summary>
        /// Is the length fixed (not variable).
        /// </summary>
        public bool? FixedLength { get; set; }

        /// <summary>
        /// Does the data type support multibyte characters.
        /// </summary>
        public bool? SupportsMultibyte { get; set; }

        /// <summary>
        /// Does the integer field value increment upon new record creation.
        /// </summary>
        public bool? AutoIncrement { get; set; }

        /// <summary>
        /// Is this field used as/part of the primary key.
        /// </summary>
        public bool? IsPrimaryKey { get; set; }

        /// <summary>
        /// Is this field used as a foreign key.
        /// </summary>
        public bool? IsForeignKey { get; set; }

        /// <summary>
        /// Is this field unique.
        /// </summary>
        public bool? IsUnique { get; set; }

        /// <summary>
        /// Is this field used as an index.
        /// </summary>
        public bool? IsIndex { get; set; }

        /// <summary>
        /// For foreign keys, the referenced table name.
        /// </summary>
        public string RefTable { get; set; }

        /// <summary>
        /// For foreign keys, the referenced table field name.
        /// </summary>
        public string RefFields { get; set; }

        /// <summary>
        /// Validations to be performed on this field.
        /// </summary>
        public List<string> Validation { get; set; }

        /// <summary>
        /// Selectable string values for client menus and picklist validation.
        /// </summary>
        public List<string> Value { get; set; }
    }
}
