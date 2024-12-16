namespace DsInsurance.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        int Add(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll();
        T GetById(Guid id);
        T Update(T entity);
        public void AddRange(IEnumerable<T> entities);
    }

}
