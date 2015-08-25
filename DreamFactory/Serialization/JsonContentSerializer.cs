namespace DreamFactory.Serialization
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// JSON content serializer.
    /// </summary>
    public class JsonContentSerializer : IContentSerializer
    {
        private readonly JsonSerializerSettings settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonContentSerializer"/> class.
        /// </summary>
        public JsonContentSerializer()
        {
            settings = new JsonSerializerSettings
                       {
                           NullValueHandling = NullValueHandling.Ignore,
                           ContractResolver = new SnakeCaseContractResolver()
                       };
        }

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

            return JsonConvert.SerializeObject(instance, settings);
        }

        /// <inheritdoc />
        public TObject Deserialize<TObject>(string content) where TObject : class
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            return JsonConvert.DeserializeObject<TObject>(content, settings);
        }

        /// <inheritdoc />
        public TObject Deserialize<TObject>(string content, TObject typeInstance) where TObject : class
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            return JsonConvert.DeserializeAnonymousType(content, typeInstance, settings);
        }
    }
}
