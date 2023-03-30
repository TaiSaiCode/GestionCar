using CarDB.Cars;
using CarDB.Owner;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;

namespace CarGestion.ViewModel
{
    public class ProprietaireViewModel : observable.Observable
    {
        #region Attributes
        private ObservableCollection<Proprietaire> _proprietaires;
        private ProprietaireSQLServerDAO _proprietairesDao;
        private Proprietaire _proprietaire;
        #endregion

        #region Property
        public ObservableCollection<Proprietaire> Proprietaires
        {
            get => _proprietaires;
            set => _proprietaires = value;
        }

        public Proprietaire Proprietaire { get => _proprietaire; set => _proprietaire = value; }

        #endregion

        public ProprietaireViewModel()
        {
            _proprietairesDao = new ProprietaireSQLServerDAO();
            RefreshProprietaires();
        }

        /// <summary>
        /// Rafraichie les voiture de l'affichage en faisant un select sur toute les voiture pour ecraser la liste de voiture actuel de tout les proprietaire
        /// </summary>
        public void RefreshProprietaires()
        {

            _proprietaires = new ObservableCollection<Proprietaire>(_proprietairesDao.GetAllproprietaire());
            foreach (Proprietaire prop in _proprietaires)
            {
                prop.Voitures = _proprietairesDao.GetAllCars(prop);
            }
            if (_proprietaire != null)
            {
                _proprietaire.Voitures = _proprietairesDao.GetAllCars(_proprietaire);
                NotifyPropertyChanged("Proprietaire");
            }

            NotifyPropertyChanged("Proprietaires");
        }

        /// <summary>
        /// Connect un proprietaire si il existe sinon le proprietaire est crée
        /// </summary>
        /// <param name="Proprietaire">nom du proprietaire</param>
        public void ConnectProprietaire(string Proprietaire)
        {
            Proprietaire? prop = _proprietairesDao.Read(Proprietaire);
            if (prop == null)
            {
                _proprietaire = new Proprietaire(Proprietaire);
                _proprietairesDao.Create(_proprietaire);
            }
            else
            {
                _proprietaire = prop;
            }     
        }

        /// <summary>
        /// Ajoute une voiture au proprietaire l'enregistre dans la base de donnée
        /// </summary>
        /// <param name="car">Voiture a ajoutée</param>
        public void AddCar(Car car)
        {
            _proprietaire.AddCar(car);

            _proprietairesDao.Update(_proprietaire);

            RefreshProprietaires();
            NotifyPropertyChanged("Proprietaire");
        }

        /// <summary>
        /// Retire une voiture au proprietaire l'enregistre dans la base de donnée
        /// </summary>
        /// <param name="car">Voiture a Retire</param>
        public void RemoveCar(Car car,CarsViewModel carsVm)
        {
            _proprietaire.RemoveCar(car);
            carsVm.RemoveCar(car.VoitureId);
            _proprietairesDao.Update(_proprietaire);

            RefreshProprietaires();
            NotifyPropertyChanged("Proprietaire");
        }
    }
}
