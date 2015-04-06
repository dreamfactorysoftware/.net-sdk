namespace DreamFactory.Api
{
    /// <summary>
    /// Represents /user API.
    /// </summary>
    public interface IUserApi
    {
        /// <summary>
        /// Gets UserSession API accessor.
        /// </summary>
        IUserSessionApi Session { get; }
    }
}
