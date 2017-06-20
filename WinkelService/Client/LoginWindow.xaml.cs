using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Client.WinkelServiceReference;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegistreerButton_Click(object sender, RoutedEventArgs e)
        {
            Registreer regWindow = new Registreer();
            regWindow.Show();
            this.Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var gebruikersnaam = Gebruikersnaam.Text;
            var wachtwoord = Wachtwoord.Password.ToString();
            using (GebruikerServiceClient client = new GebruikerServiceClient())
            {
                client.Login(1,2);
            }
        }
    }
}
