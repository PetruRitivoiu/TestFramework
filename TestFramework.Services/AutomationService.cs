using System.Net.Mail;
using System.Threading.Tasks;

namespace TestFramework.Services
{
    public class AutomationService : IAutomationService
    {
        public async Task RunTests()
        {
            using var commandLineRunner = new CommandLineRunner();
            await commandLineRunner.RunTests();
        }

        public Task SendMail()
        {
            using var smtpClient = new SmtpClient();
            using var message = new MailMessage("no-reply@Automation.com", "p.ritivoiu@gmail.com");

            message.Subject = "Test Automation results";
            message.Body = "Please find the attached report for detailed results";
            message.Attachments.Add(new Attachment(@"C:\Users\thinkpad-e560\Desktop\SeleniumTesting\ModularFramework\reports\index.html"));

            smtpClient.Send(message);
        }
    }
}
