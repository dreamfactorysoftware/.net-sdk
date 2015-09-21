using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DreamFactory.AddressBook.Startup))]

namespace DreamFactory.AddressBook
{
    using Microsoft.Owin.Security.Cookies;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = CookieAuthenticationDefaults.AuthenticationType,
                LoginPath = new PathString("/")
            });
        }
    }
}
