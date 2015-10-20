namespace DreamFactory.Model.Database
{
    using global::System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Field schema.
    /// </summary>
    public class FieldSchema
    {
        /// <summary>
        /// The API name of the field.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The displayable label for the field.
        /// </summary>
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

        /// <summary>
        /// The DSP abstract data type for this field.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// The native database type used for this field.
        /// </summary>
        [JsonProperty(PropertyName = "db_type")]
        public string DbType { get; set; }

        /// <summary>
        /// The maximum length allowed (in characters for string, displayed for numbers).
        /// </summary>
        [JsonProperty(PropertyName = "length")]
        public int? Length { get; set; }

        /// <summary>
        /// Total number of places for numbers.
        /// </summary>
        [JsonProperty(PropertyName = "precision")]
        public int? Precision { get; set; }

        /// <summary>
        /// Number of decimal places allowed for numbers.
        /// </summary>
        [JsonProperty(PropertyName = "scale")]
        public int? Scale { get; set; }

        /// <summary>
        /// Default value for this field.
        /// </summary>
        [JsonProperty(PropertyName = "default_value")]
        public string DefaultValue { get; set; }

        /// <summary>
        /// Is a value required for record creation.
        /// </summary>
        [JsonProperty(PropertyName = "required")]
        public bool? Required { get; set; }

        /// <summary>
        /// Is null allowed as a value.
        /// </summary>
        [JsonProperty(PropertyName = "allow_null")]
        public bool? AllowNull { get; set; }

        /// <summary>
        /// Is the length fixed (not variable).
        /// </summary>
        [JsonProperty(PropertyName = "fixed_length")]
        public bool? FixedLength { get; set; }

        /// <summary>
        /// Does the data type support multibyte characters.
        /// </summary>
        [JsonProperty(PropertyName = "supports_multibyte")]
        public bool? SupportsMultibyte { get; set; }

        /// <summary>
        /// Does the integer field value increment upon new record creation.
        /// </summary>
        [JsonProperty(PropertyName = "auto_increment")]
        public bool? AutoIncrement { get; set; }

        /// <summary>
        /// Is this field used as/part of the primary key.
        /// </summary>
        [JsonProperty(PropertyName = "is_primary_key")]
        public bool? IsPrimaryKey { get; set; }

        /// <summary>
        /// Is this field used as a foreign key.
        /// </summary>
        [JsonProperty(PropertyName = "is_foreign_key")]
        public bool? IsForeignKey { get; set; }

        /// <summary>
        /// Is this field unique.
        /// </summary>
        [JsonProperty(PropertyName = "is_unique")]
        public bool? IsUnique { get; set; }

        /// <summary>
        /// Is this field used as an index.
        /// </summary>
        [JsonProperty(PropertyName = "is_index")]
        public bool? IsIndex { get; set; }

        /// <summary>
        /// For foreign keys, the referenced table name.
        /// </summary>
        [JsonProperty(PropertyName = "ref_table")]
        public string RefTable { get; set; }

        /// <summary>
        /// For foreign keys, the referenced table field name.
        /// </summary>
        [JsonProperty(PropertyName = "ref_fields")]
        public string RefFields { get; set; }

        /// <summary>
        /// Validations to be performed on this field.
        /// </summary>
        [JsonProperty(PropertyName = "validation")]
        public object Validation { get; set; }

        /// <summary>
        /// Selectable string values for client menus and picklist validation.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public List<string> Value { get; set; }
    }
}
