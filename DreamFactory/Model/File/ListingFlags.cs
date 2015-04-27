namespace DreamFactory.Model.File
{
    using global::System;

    /// <summary>
    /// Files listing modes. Combine values with binary OR.
    /// </summary>
    [Flags]
    public enum ListingFlags
    {
        /// <summary>
        /// Include files in the returned listing.
        /// </summary>
        IncludeFiles = 1,

        /// <summary>
        /// Include folders in the returned listing.
        /// </summary>
        IncludeFolders = 2,

        /// <summary>
        /// List the contents of all sub-folders as well.
        /// </summary>
        IncludeSubFolders = 4,

        /// <summary>
        /// Populate any available properties.
        /// </summary>
        IncludeProperties = 8,

        /// <summary>
        /// Enable all options.
        /// </summary>
        IncludeEverything = IncludeFiles | IncludeFolders | IncludeSubFolders | IncludeProperties
    }
}
