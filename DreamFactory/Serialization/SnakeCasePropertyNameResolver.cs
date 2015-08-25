namespace DreamFactory.Serialization
{
    using System.Collections.Generic;
    using System.Text;

    /// <inheritdoc />
    public class SnakeCasePropertyNameResolver : IPropertyNameResolver
    {
        /// <inheritdoc />
        public string Resolve(string propertyName)
        {
            var parts = new List<string>();
            var currentWord = new StringBuilder();

            foreach (var c in propertyName)
            {
                if (char.IsUpper(c) && currentWord.Length > 0)
                {
                    parts.Add(currentWord.ToString());
                    currentWord.Clear();
                }
                currentWord.Append(char.ToLower(c));
            }

            if (currentWord.Length > 0)
            {
                parts.Add(currentWord.ToString());
            }

            return string.Join("_", parts.ToArray());
        }
    }
}
