namespace DreamFactory.Serialization
{
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Underscore separated, lower case property name contract resolver class.
    /// </summary>
    public class SnakeCaseContractResolver : DefaultContractResolver
    {
        /// <summary>
        /// Resolves the name of the property.
        /// </summary>
        /// <param name="propertyName">Name of the property to be resolved.</param>
        /// <returns>
        /// Resolved name of the property.
        /// </returns>
        protected override string ResolvePropertyName(string propertyName)
        {
            IPropertyNameResolver resolver = new SnakeCasePropertyNameResolver();
            return resolver.Resolve(propertyName);
        }
    }
}
