namespace DreamFactory.Serialization
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// JSON content serializer.
    /// </summary>
    public class JsonContentSerializer : IContentSerializer
    {
        /// <inheritdoc />
        public string ContentType
        {
            get { return "application/json"; }
        }

        /// <inheritdoc />
        public string Serialize<TObject>(TObject instance) where TObject: class
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }

            return JsonConvert.SerializeObject(instance);
        }

        /// <inheritdoc />
        public TObject Deserialize<TObject>(string content) where TObject : class
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            return JsonConvert.DeserializeObject<TObject>(content);
        }

        /// <inheritdoc />
        public TObject Deserialize<TObject>(string content, TObject typeInstance) where TObject : class
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            return JsonConvert.DeserializeAnonymousType(content, typeInstance);
        }
    }
}
