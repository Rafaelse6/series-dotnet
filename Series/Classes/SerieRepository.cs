using Series.Interfaces;

namespace Series.Classes
{
    public class SerieRepository : IRepository<Serie>
    {

        private List<Serie> seriesList = new List<Serie>();

        public Serie FindById(int id)
        {
            return seriesList[id];
        }

        public List<Serie> Lista()
        {
            return seriesList;
        }

        public void Add(Serie entity)
        {
            seriesList.Add(entity);
        }

        public void Update(int id, Serie entity)
        {
            seriesList[id] = entity;
        }

        public void Delete(int id)
        {
            seriesList[id].Delete();
        }

        public int NextId()
        {
            return seriesList.Count;
        }
    }
}
