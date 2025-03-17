namespace WebAppPWD.Repository
{
    public interface IGenericRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);

        void Save();
    }
}
