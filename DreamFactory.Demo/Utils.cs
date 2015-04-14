namespace DreamFactory.Demo
{
    using DreamFactory.Model;
    using DreamFactory.Model.User;

    internal static class Utils
    {
        public static Login CreateLogin()
        {
            return new Login { email = "user@mail.com", password = "userdream" };
        }
    }
}
