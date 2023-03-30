
namespace CarDB.Owner
{
    /// <summary>
    /// Interface du proprietaireDAO
    /// </summary>
    public interface ProprietaireDAO
    {
        public void Create(Proprietaire prop);
        public Proprietaire Read(string name);
        public void Update(Proprietaire prop);
        public void Delete(string name);
    }
}
