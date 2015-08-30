namespace DreamFactory.Model
{
    /// <summary>
    /// RelatedResources contains string constants of related resources that can be used when querying.
    /// </summary>
    public static class RelatedResources
    {
        /// <summary>
        /// Related UserCreated resource name.
        /// </summary>
        public const string UserCreated = "user_by_created_by_id";

        /// <summary>
        /// Related UserModified resource name.
        /// </summary>
        public const string UserModified = "user_by_last_modified_by_id";

        /// <summary>
        /// Related DefaultRole resource name.
        /// </summary>
        public const string DefaultRole = "role_by_role_id";

        /// <summary>
        /// Related StorageService resource name.
        /// </summary>
        public const string StorageService = "service_by_storage_service_id";

        /// <summary>
        /// Related AppLookups resource name.
        /// </summary>
        public const string AppLookups = "app_lookup_by_app_id";

        /// <summary>
        /// Related UsersInAppLookup resource name.
        /// </summary>
        public const string UsersInAppLookup = "user_by_app_lookup";

        /// <summary>
        /// Related Apps resource name.
        /// </summary>
        public const string Apps = "app_to_app_group_by_app_id";

        /// <summary>
        /// Related AppGroups resource name.
        /// </summary>
        public const string AppGroups = "app_group_by_app_to_app_group";

        /// <summary>
        /// Related UserRoles resource name.
        /// </summary>
        public const string UserRoles = "user_to_app_to_role_by_app_id";

        /// <summary>
        /// Related Roles resource name.
        /// </summary>
        public const string Roles = "role_by_user_to_app_to_role";

        /// <summary>
        /// Related Users resource name.
        /// </summary>
        public const string Users = "user_by_user_to_app_to_role";
    }
}
