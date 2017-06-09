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
            using (WinkelDbModelContainer ctx = new WinkelDbModelContainer())
            {
                var gebruikers = from gebruiker in ctx.GebruikerSet select gebruiker;
                foreach (var g in gebruikers)
                {
                    if (g.Gebruikersnaam == gebruikersnaam)
                    {
                        return null;
                    }
                    else
                    {
                        char[] gebruikersnaamArray = gebruikersnaam.ToCharArray();
                        wachtwoord = gebruikersnaamArray.Reverse().ToString();
                        Gebruiker gebruiker =
                            new Gebruiker() {Gebruikersnaam = gebruikersnaam, Wachtwoord = wachtwoord};
                        ctx.GebruikerSet.Add(gebruiker);
                        ctx.SaveChanges();
                    }
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
