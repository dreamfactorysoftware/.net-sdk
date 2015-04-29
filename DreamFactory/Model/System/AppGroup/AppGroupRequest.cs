// ReSharper disable InconsistentNaming
namespace DreamFactory.Model.System.AppGroup
{
    using DreamFactory.Model.System.App;

    /// <summary>
    /// AppGroupResponse.
    /// </summary>
    public class AppGroupRequest
    {
        /// <summary>
        /// Identifier of this application group.
        /// </summary>
        public int? id { get; set; }

        /// <summary>
        /// Displayable name of this application group.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Description of this application group.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Related apps by app to group assignment.
        /// </summary>
        public RelatedApps apps { get; set; }
    }
}