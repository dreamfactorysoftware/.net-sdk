namespace DreamFactory.Model.System.Custom
{
    using DreamFactory.Model.System.User;
    using global::System;

    /// <summary>
    /// CustomResponse.
    /// </summary>
    public class CustomResponse
    {
        /// <summary>
        /// Name of the created resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value of the created resource.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Date when the resource was created.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Date when the resource was modified.
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// UserId that created the resource.
        /// </summary>
        public int? CreatedById { get; set; }

        /// <summary>
        /// UserId that modified the resource.
        /// </summary>
        public int? LastModifiedById { get; set; }

        /// <summary>
        /// User that created the resource.
        /// </summary>
        /// <returns cref="UserResponse"></returns>
        public UserResponse UserByCreatedById { get; set; }

        /// <summary>
        /// User that modified the resource.
        /// </summary>
        /// <returns cref="UserResponse"></returns>
        public UserResponse UserByLastModifiedById { get; set; }
    }
}
