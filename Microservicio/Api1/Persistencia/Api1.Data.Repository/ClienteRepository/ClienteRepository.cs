using Api.core.abstraction.Contracts;
using Api1.Data.Models;
using Api1.Data.SqlServer;
using Microsoft.EntityFrameworkCore;

public class ClienteRepository : IRepository<Cliente>
{
    DbFacturacion context;
    public ClienteRepository(DbFacturacion context)
    {
        this.context = context;
    }

    public async Task<bool> Actualizar(Cliente cliente)
    {
        try
        {
            context.Entry(cliente).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            
            throw new Exception("Error al actualizar el cliente", ex.GetBaseException());
        }
    }

    public async Task<bool> Crear(Cliente cliente)
    {
        try
        {
            context.Clientes.Add(cliente);
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            
            throw new Exception("Error al actualizar el cliente", ex.GetBaseException());
        }
    }

    public async Task<bool> EliminarAsync(int id)
    {
        try
        {
            var cliente = await context.Clientes.FindAsync(id);
                context.Clientes.Remove(cliente);
                await context.SaveChangesAsync();
                return true;
        }
        catch (Exception ex)
        {

            throw new Exception("Error al eliminar el cliente", ex.GetBaseException());
        }
    }

    public async Task<Cliente> ObtenerPorId(int id)
    {
        return await context.Clientes.FindAsync(id);
    }

    // Metodo sincrono para la obtencion de todos los clientes 
    public IQueryable<Cliente> ObtenerTodo()
    {
        return context.Clientes.AsQueryable();
    }
}
