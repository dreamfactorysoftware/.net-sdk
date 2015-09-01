namespace DreamFactory.Model.System.Custom
{
    /// <summary>
    /// CustomRequest.
    /// </summary>
    public class CustomRequest
    {
        /// <summary>
        /// Id of the user linked to custom setting.
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Name of the resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value of the resource.
        /// </summary>
        public string Value { get; set; }
    }
}
