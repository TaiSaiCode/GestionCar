
namespace CarDB.Cars
{
    /// <summary>
    /// Interface Car DAO
    /// </summary>
    public interface CarDAO
    {
        public void Create(Car car);
        public Car Read(int id);
        public void Update(Car car);
        public void Delete(int id);
    }
}
