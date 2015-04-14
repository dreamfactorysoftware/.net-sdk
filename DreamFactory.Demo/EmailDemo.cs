namespace DreamFactory.Demo
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model;
    using DreamFactory.Model.Email;
    using DreamFactory.Model.User;
    using DreamFactory.Rest;

    public class EmailDemo
    {
        public static async Task Run(string baseAddress)
        {
            // Login first
            IRestContext context = new RestContext(baseAddress);
            IUserApi userSessionApi = context.Factory.CreateUserApi();
            Session session = await userSessionApi.LoginAsync("todoangular", Utils.CreateLogin());
            Console.WriteLine("Logged in as {0}", session.display_name);

            // Send an email
            Console.WriteLine("Sending email...");
            EmailRequest request = CreateEmailRequest();
            IEmailApi emailApi = context.Factory.CreateEmailApi("email");
            int count = await emailApi.SendEmailAsync(request);
            Console.WriteLine("{0} email(s) sent.", count);
        }

        private static EmailRequest CreateEmailRequest()
        {
            EmailAddress address = new EmailAddress { email = "motodrug@gmail.com" };
            return new EmailRequest { to = new List<EmailAddress> { address }, subject = "Hello from the demo!", body_text = "Hello, moto!" };
        }
    }
}