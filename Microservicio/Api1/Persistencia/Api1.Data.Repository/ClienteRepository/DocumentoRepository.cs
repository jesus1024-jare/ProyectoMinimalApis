using System;
using Api1.Data.Models;
using Api1.Data.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace Api1.Data.Repository.ClienteRepository;

public class DocumentoRepository : IQueryService<Documento>
{
    DbFacturacion context;
    public DocumentoRepository(DbFacturacion context)
    {
        this.context = context;
    }
    public async Task<bool> Actualizar(Documento cliente)
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

    public async Task<bool> Crear(Documento cliente)
    {
        try
        {
            context.Documentos.Add(cliente);
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
            var cliente = await context.Documentos.FindAsync(id);
            context.Documentos.Remove(cliente);
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {

            throw new Exception("Error al eliminar el cliente", ex.GetBaseException());
        }
    }

    public async Task<Documento> ObtenerPorId(int id)
    {
        return await context.Documentos.FindAsync(id);
    }

    public IQueryable<Documento> ObtenerTodo()
    {
        return context.Documentos.AsQueryable();
    }
}
