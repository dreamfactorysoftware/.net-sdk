namespace DreamFactory.Model.System.Service
{
    using DreamFactory.Model.System.App;
    using DreamFactory.Model.System.Role;
    using global::System;
    using global::System.Collections.Generic;

    /// <summary>
    /// ServiceResponse.
    /// </summary>
    public class ServiceResponse
    {
        /// <summary>
        /// Identifier of this service.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Displayable name of this service.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Label of this service.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Description of this service.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// True if this service is active for use.
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// One of the supported service types.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Indicates whether this service is mutable.
        /// </summary>
        public bool? Mutable { get; set; }

        /// <summary>
        /// Indicates whether this service can be deleted.
        /// </summary>
        public bool? Deletable { get; set; }

        /// <summary>
        /// Date this service was created.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Date this service was last modified.
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// Id of the user that created this service.
        /// </summary>
        public int? CreatedById { get; set; }

        /// <summary>
        /// Id of the user that last modified this service.
        /// </summary>
        public int? LastModifiedById { get; set; }
    }
}