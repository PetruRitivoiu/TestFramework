using System.Threading.Tasks;

namespace TestFramework.Services
{
    public class TestsService
    {
        public async Task RunTests()
        {
            using var commandLineRunner = new CommandLineRunner();
            await commandLineRunner.RunTests();
        }

}
}
