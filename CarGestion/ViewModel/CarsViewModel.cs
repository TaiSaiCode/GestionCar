using CarDB.Cars;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace CarGestion.ViewModel
{
    public class CarsViewModel : observable.Observable
    {
        #region Attributes
        private ObservableCollection<Car> _cars;
        private CarSQLServerDAO _carsDao;
        #endregion

        #region Property
        public ObservableCollection<Car> Cars
        {
            get => _cars;
            set => _cars = value;
        }

        #endregion

        public CarsViewModel()
        {
            _carsDao = new CarSQLServerDAO();
            RefreshCars();
        }

        /// <summary>
        /// Rafraichie l'affichage de toute les voiture
        /// </summary>
        public void RefreshCars()
        {
            _cars = new ObservableCollection<Car>(_carsDao.GetAllCar());
            NotifyPropertyChanged("Cars");
        }

        /// <summary>
        /// Crée une voiture et l'enregistre dans la base de donnée
        /// </summary>
        /// <param name="car">Voiture a crée</param>
        public void CreateCar(Car car)
        {
            _carsDao.Create(car);
            RefreshCars();
        }

        /// <summary>
        /// Retire une voiture de la base de donnée
        /// </summary>
        /// <param name="car">voiture a supprimée</param>
        public void RemoveCar(int carId)
        {
            _carsDao.Delete(carId);
            RefreshCars();
        }
    }
}
