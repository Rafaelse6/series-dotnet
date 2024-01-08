namespace Series.Interfaces
{
    public interface IRepository<T>
    {

        List<T> Lista();

        T FindById(int id);

        void Add(T entity);

        void Delete(int id); 
        
        void Update(int id, T entity);

        int NextId();
    }
}
