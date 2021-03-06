﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Client
{
    public partial class Registreer : Window
    {
        public Registreer()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Gebruikersnaam.Text != null)
            {
                using (WinkelServiceReference.GebruikerServiceClient client =
                    new WinkelServiceReference.GebruikerServiceClient())
                {
                    var result = client.Registreer(Gebruikersnaam.Text);
                    if (result == Gebruikersnaam.Text)
                    {
                        Console.WriteLine("User bestaat");
                        NieuwWachtwoord.Content = "Gebruikersnaam " + Gebruikersnaam.Text + " bestaat al.";
                    }
                    else
                    {
                        NieuwWachtwoord.Content = "Registratie";
                        NieuwWachtwoord.Content = result;
                    }
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
