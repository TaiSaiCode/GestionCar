using CarGestion.Views;
using System.Windows;

namespace CarsGestion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frame.Navigate(new Acceuil());

        }
    }
}
