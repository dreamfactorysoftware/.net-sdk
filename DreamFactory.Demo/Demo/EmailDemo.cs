namespace DreamFactory.Demo.Demo
{
    using System;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model.Builder;
    using DreamFactory.Model.Email;
    using DreamFactory.Rest;

    public class EmailDemo : IRunnable
    {
        public async Task RunAsync(IRestContext context)
        {
            // Send an email
            Console.WriteLine("Sending email...");

            // Using the builder is good for simple emails
            EmailRequest request = new EmailRequestBuilder().AddTo("inbox@mail.com")
                                                            .WithSubject("Hello")
                                                            .WithBody("Hello, world!")
                                                            .Build();

            IEmailApi emailApi = context.Factory.CreateEmailApi("email");
            int count = await emailApi.SendEmailAsync(request);

            Console.WriteLine("{0} email(s) sent.", count);
        }
    }
}