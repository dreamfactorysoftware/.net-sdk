namespace DreamFactory.Model.Database
{
    using Newtonsoft.Json;

    /// <summary>
    /// Stored procedure parameter descriptor.
    /// </summary>
    public class StoredProcParam
    {
        /// <summary>
        /// Name of the parameter, required for OUT and INOUT types, must be the same as the stored procedure's parameter name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Parameter type of IN, OUT, or INOUT, defaults to IN.
        /// </summary>
        [JsonProperty(PropertyName = "param_type")]
        public string ParamType { get; set; }

        /// <summary>
        /// Value of the parameter, used for the IN and INOUT types, defaults to NULL.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        /// <summary>
        /// For INOUT and OUT parameters, the requested type for the returned value, i.e. integer, boolean, string, etc. Defaults to value type for INOUT and string for OUT.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// For INOUT and OUT parameters, the requested length for the returned value. May be required by some database drivers.
        /// </summary>
        [JsonProperty(PropertyName = "length")]
        public int? Length { get; set; }
    }
}