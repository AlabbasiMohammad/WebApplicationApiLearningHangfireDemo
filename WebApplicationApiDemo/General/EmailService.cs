using WebApplicationApiDemo.General.Interfaces;

namespace WebApplicationApiDemo.General
{
    public class EmailService : IEmailService
    {
        public void GettingStartedEmail(string email, string name)
        {
            Console.WriteLine($"Sending getting started email to {name} at {email}");
        }

        public void SendWelcomeEmail(string email, string name)
        {
            Console.WriteLine($"Sending welcome email to {name} at {email}");
        }
    }
}
