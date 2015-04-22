﻿// ReSharper disable InconsistentNaming
namespace DreamFactory.Model.Database
{
    /// <summary>
    /// Stored procedure parameter descriptor.
    /// </summary>
    public class StoredProcParam
    {
        /// <summary>
        /// Name of the parameter, required for OUT and INOUT types, must be the same as the stored procedure's parameter name.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Parameter type of IN, OUT, or INOUT, defaults to IN.
        /// </summary>
        public string param_type { get; set; }

        /// <summary>
        /// Value of the parameter, used for the IN and INOUT types, defaults to NULL.
        /// </summary>
        public string value { get; set; }

        /// <summary>
        /// For INOUT and OUT parameters, the requested type for the returned value, i.e. integer, boolean, string, etc. Defaults to value type for INOUT and string for OUT.
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// For INOUT and OUT parameters, the requested length for the returned value. May be required by some database drivers.
        /// </summary>
        public int? length { get; set; }
    }
}