using CarDB.Owner;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDB.Cars
{
    [Table("Cars")]
    public class Car
    {
        #region Attributes

        private int _carsId;
        [Column("Nom")]
        private string _name;
        [Column("Brand")]
        private string _brand;
        [Column("Modele")]
        private string _model;
        [Column("Annee")]
        private short _year;
        [ForeignKey("ProprietaireId")]
        private Proprietaire _proprietaire;
        [Column("Image")]
        private byte[] _image;

        #endregion

        #region Property

        public int VoitureId { get => _carsId; set => _carsId = value; }
        public string Nom { get => _name; set => _name = value; }
        public string Marque { get => _brand; set => _brand = value; }
        public short Annee { get => _year; set => _year = value; }
        public string Modele { get => _model; set => _model = value; }
        public Proprietaire Proprietaire { get => _proprietaire; set => _proprietaire = value; }
        public byte[] Image { get => _image; set => _image = value; }

        #endregion

        /// <summary>
        /// Constructeur de la voiture
        /// </summary>
        /// <param name="name">nom</param>
        /// <param name="brand">marque</param>
        /// <param name="year">année de la voiture</param>
        /// <param name="model">model</param>
        public Car(Proprietaire prop, string name, string brand, short year,string model,byte[] image)
        {
            _proprietaire = prop;
            _image = image;
            _name = name;
            _brand = brand;
            _model = model;
            _year = year;
        }

        public Car()
        {

        }
    }
}
