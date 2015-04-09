namespace DreamFactory.Demo
{
    using DreamFactory.Model;

    internal static class Utils
    {
        public static Login CreateLogin()
        {
            return new Login { email = "user@mail.com", password = "userdream" };
        }
    }
}
