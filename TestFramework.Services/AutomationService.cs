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
    }
}
