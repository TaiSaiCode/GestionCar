using CarDB.Cars;
using CarGestion.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CarsGestion.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Page
    {
        #region Attributes
        private byte[] _imageTmpCreation;
        private Image _imageCreation;
        private CarsViewModel _carsVm;
        private ProprietaireViewModel _proprietaireVm;
        #endregion

        public MainView(ProprietaireViewModel propVm) 
        {
            InitializeComponent();
            InitCreateCarStackPanel();
            _proprietaireVm = propVm;
            _carsVm = new CarsViewModel();
            PropList.DataContext = _proprietaireVm;
            DataContext = _carsVm;
            PropLabel.DataContext = _proprietaireVm;
            _proprietaireVm.RefreshProprietaires();
            ListBoxYourCars.DataContext = _proprietaireVm;
        }

        /// <summary>
        /// Initialise la page de création d'un vehicule avec des inputs générer via les propriétés de la classe "Car'
        /// </summary>
        private void InitCreateCarStackPanel()
        {
            Car car = new Car();

            //Parcours tout les propriétés
            foreach (var prop in car.GetType().GetProperties())
            {
                if (prop.Name == "Image")
                {
                    Button b = new Button
                    {
                        Content = "Ajouter une voiture",
                        Width = 120,
                        MinHeight = 40,
                        Margin = new Thickness(10),
                    };
                    b.Click += CreateCarButton_Click;
                    CreateCarStackPanel.Children.Add(b);
                }

                if (prop.Name != "VoitureId" && prop.Name != "Proprietaire" && prop.Name != "ProprietaireId" && prop.Name != "Image")
                {
                    TextBlock t = new TextBlock
                    {
                        Text = prop.Name +'*',
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                    };
                    TextBox text = new TextBox
                    {
                        Name = prop.Name,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        MinWidth= 200,
                    };

                    CreateCarStackPanel.Children.Add(t);
                    CreateCarStackPanel.Children.Add(text);                  
                }         
            }
        }

        /// <summary>
        /// Ouvre une boite de dialogue filter pour afficher seulement des fichier de type image
        /// </summary>
        private void AddImageButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Sélectionner une image";
            openFileDialog.Filter = "Fichiers d'images (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == true)
            {
                // Recupère le chemin du fichier
                string cheminFichier = openFileDialog.FileName;

                // Charge le fichier dans un tableau de bytes
                _imageTmpCreation = File.ReadAllBytes(cheminFichier);

                // Converti le tableau de bytes en image
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = new MemoryStream(_imageTmpCreation);
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
              
                // Affecte la source de limage wpf au bitmap de l'image importer
                CarImage.Source = bitmap;
            }
        }

        /// <summary>
        /// Crée la voiture a partir des champs dans le stackpanel de creation de voiture
        /// </summary>
        private void CreateCarButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                List<TextBox?> textbox = CreateCarStackPanel.Children.OfType<TextBox?>().Where(t => t.Name != "VoitureId").ToList();
                if (!String.IsNullOrEmpty(textbox[0].Text))
                {
                    if (textbox[2].Text.Length == 4)
                    {
                        //Crée la voiture a partie des elements des inputs dans l'onglet 'Ajout d'un véhicule'
                        _proprietaireVm.AddCar(new Car(_proprietaireVm.Proprietaire,textbox[0].Text, textbox[1].Text, short.Parse(textbox[2].Text), textbox[3].Text,_imageTmpCreation));


                        _carsVm.RefreshCars();
                        TabControler.SelectedIndex = 0;
                        MessageBox.Show("Voiture crée avec succès");
                    }
                    else
                    {
                        MessageBox.Show("L'année entrée n'est pas valide");
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez saisir le nom de la voiture !");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }        
        }

        private void DeleteCarButton_Click(object sender, RoutedEventArgs e)
        {
            _proprietaireVm.RemoveCar(((sender as Button).DataContext as Car),_carsVm);
        }
    }
}
