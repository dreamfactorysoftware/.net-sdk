namespace DreamFactory.Demo
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model.Email;
    using DreamFactory.Rest;

    public class EmailDemo
    {
        public static async Task Run(IRestContext context)
        {
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