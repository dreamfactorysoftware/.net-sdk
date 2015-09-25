namespace DreamFactory.Serialization
{
    /// <summary>
    /// Implementation of a property name resolver class.
    /// </summary>
    public interface IPropertyNameResolver
    {
        /// <summary>
        /// For a given name of the property returns resolved property name.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>Resolved property name.</returns>
        string Resolve(string propertyName);
    }
}