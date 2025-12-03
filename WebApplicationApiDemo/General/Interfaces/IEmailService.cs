namespace WebApplicationApiDemo.General.Interfaces
{
    public interface IEmailService
    {
        void SendWelcomeEmail(string email, string name);
        void GettingStartedEmail(string email, string name);
    }
}
