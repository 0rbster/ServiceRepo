using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WinkelService;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host =
                new ServiceHost(typeof(WinkelService.GebruikerService)))
            {
                host.Open();
                Console.WriteLine("User service running...");
                Console.WriteLine("Press enter to terminate Host.");
                Gebruiker test = new Gebruiker() {Gebruikersnaam = "Test", Wachtwoord = "tseT", Saldo = 500.00};
                using (var ctx = new WinkelDbModelContainer())
                {
                    try
                    {
                        ctx.GebruikerSet.Add(test);
                        ctx.SaveChanges();
                    } catch(Exception ex) { Console.WriteLine(ex.Message); }
                
                }
                Console.ReadKey();
            }
        }
    }
}
