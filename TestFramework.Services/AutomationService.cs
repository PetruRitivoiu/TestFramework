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

        public async Task SendMail()
        {
            await Task.Run(() =>
            {
                using var smtpClient = new SmtpClient()
                {
                    EnableSsl = false,
                    UseDefaultCredentials = true,
                    DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis
                };

                using var message = new MailMessage("no-reply@automation.com", "p.ritivoiu@gmail.com");

                message.Subject = "Test Automation results";
                message.Body = "Please find the attached report for detailed results";
                message.Attachments.Add(new Attachment(@"C:\Users\petru.ritivoiu\OneDrive - 888Holdings\Desktop\TestFramework\reports\index.html"));

                smtpClient.Send(message);
            }).ConfigureAwait(false);
        }
    }
}
