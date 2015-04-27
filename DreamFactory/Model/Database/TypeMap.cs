namespace DreamFactory.Model.Database
{
    using global::System;
    using global::System.Collections.Generic;

    internal static class TypeMap
    {
        private static readonly Dictionary<Type, string> Types = new Dictionary<Type, string>
        {
            { typeof (string), "string" },
            { typeof (int), "integer" },
            { typeof (long), "integer" },
            { typeof (bool), "boolean" },
            { typeof (byte[]), "binary" },
            { typeof (float), "float" },
            { typeof (double), "double" },
            { typeof (decimal), "decimal" },
            { typeof (DateTime), "datetime" },
        };

        public static string GetTypeName(Type fieldType)
        {
            string typeName;
            if (!Types.TryGetValue(fieldType, out typeName))
            {
                throw new NotSupportedException("Type is not supported by database interface: " + fieldType.Name);
            }

            return typeName;
        }
    }
}
