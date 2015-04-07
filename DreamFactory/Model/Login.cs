// ReSharper disable InconsistentNaming
namespace DreamFactory.Model
{
    /// <summary>
    /// Login request.
    /// </summary>
    public class Login : IModel
    {
        /// <summary>
        /// e-mail.
        /// </summary>
        public string email { get; set; }
        
        /// <summary>
        /// Password.
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// Duration of the session, Defaults to 0, which means until browser is closed.
        /// </summary>
        public int? duration { get; set; }
    }
}
