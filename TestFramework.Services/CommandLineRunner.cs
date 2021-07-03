using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Services
{
    class CommandLineRunner : IDisposable
    {
        private bool _disposed = false;
        private Process proc;

        public CommandLineRunner()
        {
            proc = new Process();
        }

        ~CommandLineRunner() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                proc.Close();
            }

            _disposed = true;
        }


        private async Task ExecuteCommand(object command)
        {
            await Task.Run(() =>
            {
                try
                {
                    ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + command)
                    {
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    // Now we create a process, assign its ProcessStartInfo and start it                
                    proc.StartInfo = procStartInfo;
                    proc.Start();

                    // Get the output into a string if you want!
                    string result = proc.StandardOutput.ReadToEnd();
                    // Display the command output.
                    Debug.WriteLine(result);

                    proc.WaitForExit();
                }
                catch (Exception objException)
                {
                    // Log the exception
                    Debug.WriteLine(objException.Message);
                }
            });
        }

        public async Task RunTests()
        {
            var command = @"dotnet vstest C:\Users\petru.ritivoiu\OneDrive - 888Holdings\Desktop\TestFramework-master\TestFramework.Tests\bin\Debug\netcoreapp3.1\TestFramework.Tests.dll";

            await ExecuteCommand(command);
        }
    }
}
