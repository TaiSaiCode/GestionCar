using CarDB.Cars;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDB.Owner
{
    /// <summary>
    /// Class _proprietaire
    /// </summary>
    [Table("Proprietaire")]
    public class Proprietaire
    {
        #region Attributes
        private string _name;
        [Column("Voitures")]
        private List<Car> _voitures;
        private int _voitureCount;
        #endregion

        #region Property
        public string Name { get => _name; }
        public List<Car> Voitures 
        { 
            get => _voitures;
            set
            {
                _voitures = value;
                _voitureCount = _voitures.Count;
            }
        }
        public int VoituresCount { get => _voitureCount; }
        #endregion

        /// <summary>
        /// Constructeur du _proprietaire
        /// </summary>
        /// <param name="name">nom du _proprietaire</param>
        public Proprietaire(string name)
        {
            _voitures = new List<Car>();
            _voitureCount = 0;
            _name = name;
        }

        /// <summary>
        /// Ajoute un voiture dans la liste des voiture et incremente le nombre de voiture
        /// </summary>
        /// <param name="car">ajoute un voiture</param>
        public void AddCar(Car car)
        {
            _voitures.Add(car);
            _voitureCount++;
        }

        /// <summary>
        /// Retire un voiture dans la liste des voiture et decremente le nombre de voiture
        /// </summary>
        /// <param name="car">voiture a retirer</param>
        public void RemoveCar(Car car)
        {
            _voitures.Remove(car);
            _voitureCount--;
        }

        public override string? ToString()
        {
            return _name;
        }
    }
}
