using CarDB.Cars;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarDB.Owner
{
    public class ProprietaireSQLServerDAO : ProprietaireDAO
    {
        /// <summary>
        /// Crée un _proprietaire dans la base de donnée
        /// </summary>
        /// <param name="proprietaire">_proprietaire</param>
        public void Create(Proprietaire proprietaire)
        {
            try
            {
                using (MyContext context = new MyContext())
                {
                    context.Proprietaires.Add(proprietaire);
                    context.SaveChanges();
                }    
            }
            catch (Exception e)
            {
                throw e;
            }          
        }
        
        /// <summary>
        /// Supprime un _proprietaire
        /// </summary>
        /// <param name="name">nom du _proprietaire</param>
        public void Delete(string name)
        {
            try
            {
                using (MyContext context = new MyContext())
                {
                    context.Proprietaires.Remove(context.Proprietaires.FirstOrDefault(c => c.Name == name));
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Recupere un _proprietaire
        /// </summary>
        /// <param name="name">nom du _proprietaire</param>
        /// <returns>Le _proprietaire</returns>
        public Proprietaire Read(string name)
        {
            Proprietaire? proprietaire = null;
            try
            {
                using (MyContext context = new MyContext())
                {
                    proprietaire = context.Proprietaires.FirstOrDefault(c => c.Name == name);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return proprietaire;
        }

        /// <summary>
        /// Met a jour le _proprietaire
        /// </summary>
        /// <param name="proprietaire">_proprietaire a mettre a jour</param>
        public void Update(Proprietaire proprietaire)
        {
            try
            {
                using (MyContext context = new MyContext())
                {
                    context.Proprietaires.Update(proprietaire);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Recupere tout les _proprietaire inscrit
        /// </summary>
        /// <returns>Liste de _proprietaire</returns>
        public List<Proprietaire> GetAllproprietaire()
        {
            List<Proprietaire>? proprietaire = null;
            try
            {
                using (MyContext context = new MyContext())
                {
                    proprietaire = context.Proprietaires.ToList();
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return proprietaire;
        }

        /// <summary>
        /// Recupere tout les voiture du proprietaire
        /// </summary>
        /// <returns>Liste de voitures</returns>
        public List<Car>? GetAllCars(Proprietaire proprietaire)
        {
            List<Car>? cars = new List<Car>();
            try
            {
                using (MyContext context = new MyContext())
                {
                    cars = context.Cars.Where(c => c.Proprietaire.Name == proprietaire.Name).ToList();
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return cars;
        }
    }
}
