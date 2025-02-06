
using Api.core.abstraction.Contracts;

public interface IQueryService<T> : IDomainModels
{
    Task<bool> Crear(T cliente);
    Task<bool> Actualizar(T cliente);
    Task<bool> EliminarAsync(int id);
    Task<T> ObtenerPorId(int id);
    IQueryable<T> ObtenerTodo();
}
