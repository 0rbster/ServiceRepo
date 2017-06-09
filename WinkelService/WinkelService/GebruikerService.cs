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
        public bool Registreer(string gebruikersnaam)
        {
            using (WinkelDbModelContainer ctx = new WinkelDbModelContainer())
            {
                var gebruikers = from gebruiker in ctx.GebruikerSet select gebruiker;
                foreach (var g in gebruikers)
                {
                    if (g.Gebruikersnaam == gebruikersnaam)
                    {
                        return "";
                    }
                    else
                    {
                        char[] gebruikersnaamArray = gebruikersnaam.ToCharArray();
                        gebruikersnaamArray.Reverse();
                        string wachtwoord = gebruikersnaamArray.ToString();
                        Gebruiker gebruiker =
                            new Gebruiker() {Gebruikersnaam = gebruikersnaam, Wachtwoord = wachtwoord};
                        ctx.GebruikerSet.Add(gebruiker);
                        ctx.SaveChanges();
                    }
                }
            }
            return true;
        }
        public int Login(int x, int y)
        {
            return x + y;
        }
    }
}
