namespace DreamFactory.Model.File
{
    /// <summary>
    /// Files listing modes. To be combined with binary OR.
    /// </summary>
    public enum ListFiles
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
        IncludeProperties = 8
    }
}
