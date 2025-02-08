
using Api.core.abstraction.Contracts;

public interface IQueryService<T> : IDomainModels
{
    Task<bool> Create(T document);
    Task<bool> Update(T document);
    Task<bool> DeleteAsync(int id);
    Task<T> GetById(int id);
    IQueryable<T> GetAll();
}
