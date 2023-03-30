using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarDB.Cars
{
    public class CarSQLServerDAO : CarDAO
    {
        /// <summary>
        /// Crée une voiture
        /// </summary>
        /// <param name="car"></param>
        public void Create(Car car)
        {
            try
            {
                using (MyContext context = new MyContext())
                {
                    context.Cars.Add(car);
                    context.SaveChanges();
                }    
            }
            catch (Exception e)
            {
                throw e;
            }
           
        }

        /// <summary>
        /// Supprime une voiture
        /// </summary>
        /// <param name="id">_id de la voiture</param>
        public void Delete(int id)
        {
            try
            {
                using (MyContext context = new MyContext())
                {
                    context.Cars.Remove(context.Cars.FirstOrDefault(c => c.VoitureId == id));
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Recupere une voiture par ID
        /// </summary>
        /// <param name="id">_id de la voiture</param>
        /// <returns>La voiture</returns>
        public Car Read(int id)
        {
            Car? car = null;
            try
            {
                using (MyContext context = new MyContext())
                {
                    car = context.Cars.FirstOrDefault(c => c.VoitureId == id);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return car;
        }

        /// <summary>
        /// Met a jour une voiture
        /// </summary>
        /// <param name="car">Voiture a mettre a jour</param>
        public void Update(Car car)
        {
            try
            {
                using (MyContext context = new MyContext())
                {
                    context.Cars.Update(car);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Recupere tout les vehicule inscrit
        /// </summary>
        /// <returns>Liste de voiture</returns>
        public List<Car> GetAllCar()
        {
            List<Car>? car = null;
            try
            {
                using (MyContext context = new MyContext())
                {
                    car = context.Cars.ToList();
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return car;
        }
    }
}
