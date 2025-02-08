namespace Api.core.abstraction.Contracts
{
    public interface IRepository<T> : IDomainModels
    {
        Task<bool> Create(T customer);
        Task<bool> Update(T customer);
        Task<bool> DeleteAsync(int id);
        Task<T> GetById(int id);
        IQueryable<T> GetAll();
    }
}