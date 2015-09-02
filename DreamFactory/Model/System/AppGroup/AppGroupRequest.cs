namespace DreamFactory.Model.System.AppGroup
{
    using DreamFactory.Model.System.App;
    using global::System.Collections.Generic;

    /// <summary>
    /// AppGroupResponse.
    /// </summary>
    public class AppGroupRequest : IRecord
    {
        /// <summary>
        /// Identifier of this application group.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Displayable name of this application group.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of this application group.
        /// </summary>
        public string Description { get; set; }
    }
}