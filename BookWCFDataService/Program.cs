using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace BookWCFDataService
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var exitCode = HostFactory.Run(x =>
                {

                    x.Service<WindowsService>(s =>
                    {
                        s.ConstructUsing(service => new WindowsService());

                        s.WhenStarted(service => service.Start());
                        s.WhenStopped(service => service.Stop());

                    });
                    x.RunAsLocalSystem();
                    x.SetServiceName("Service name");
                    x.SetDisplayName("Service display name");
                    x.SetDescription("Service description");

                });

                int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
                Environment.ExitCode = exitCodeValue;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(-1);
            }

        }
    }
}
