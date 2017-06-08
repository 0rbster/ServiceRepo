using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    class program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host =
                new ServiceHost(typeof(WinkelService.DateService)))
            {
                host.Open();
                Console.WriteLine("Date service running...");
                Console.WriteLine("Press enter to terminate Host.");
                Console.ReadKey();
            }
        }
    }
}
