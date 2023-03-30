using CarDB.Owner;
using CarGestion.ViewModel;
using CarsGestion;
using CarsGestion.Views;
using System.Windows;
using System.Windows.Controls;

namespace CarGestion.Views
{
    /// <summary>
    /// Interaction logic for Acceuil.xaml
    /// </summary>
    public partial class Acceuil : Page
    {
        public Acceuil()
        {
            InitializeComponent();
        }

        private void ConnexionButton_Click(object sender, RoutedEventArgs e)
        {
            ProprietaireViewModel _proprietaireVm = new ProprietaireViewModel();
            if (!string.IsNullOrEmpty(ProprietairePseudo.Text)) 
            {

                _proprietaireVm.ConnectProprietaire(ProprietairePseudo.Text);
                (Window.GetWindow(App.Current.MainWindow) as MainWindow)?.frame.NavigationService.Navigate(new MainView(_proprietaireVm));
            }
            else
            {
                MessageBox.Show("Veuillez saisir un nom de proprietaire");
            }
        }
    }
}
