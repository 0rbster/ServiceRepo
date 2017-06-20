using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WinkelService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DateService" in both code and config file together.
    public class GebruikerService : IGebruikerService
    {
        public string Registreer(string gebruikersnaam)
        {
            string wachtwoord = null;
            using (var ctx = new WinkelDbModelContainer())
            {
                try
                {
                    var gebruikersnamen = from gebruiker in ctx.GebruikerSet select gebruiker.Gebruikersnaam;

                    if (!gebruikersnamen.Any())
                    {
                        char[] gebruikersnaamArray = gebruikersnaam.ToCharArray();
                        wachtwoord = gebruikersnaamArray.Reverse().ToString();
                        Console.WriteLine(wachtwoord);
                        Gebruiker gebruiker =
                            new Gebruiker() { Gebruikersnaam = gebruikersnaam, Wachtwoord = wachtwoord, Saldo = 20.00 };
                        ctx.GebruikerSet.Add(gebruiker);
                        return wachtwoord;
                    }

                    foreach (var g in gebruikersnamen)
                    {
                        if (g == gebruikersnaam)
                        {
                            Console.WriteLine(gebruikersnaam);
                            return gebruikersnaam;
                        }
                        char[] gebruikersnaamArray = gebruikersnaam.ToCharArray();
                        wachtwoord = gebruikersnaamArray.Reverse().ToString();
                        Console.WriteLine(wachtwoord);
                        Gebruiker gebruiker = new Gebruiker()
                            {
                                Gebruikersnaam = gebruikersnaam,
                                Wachtwoord = wachtwoord,
                                Saldo = 20.00
                            };
                        ctx.GebruikerSet.Add(gebruiker);
                    }
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return wachtwoord;
        }
        public int Login(int x, int y)
        {
            return x + y;
        }
    }
}
