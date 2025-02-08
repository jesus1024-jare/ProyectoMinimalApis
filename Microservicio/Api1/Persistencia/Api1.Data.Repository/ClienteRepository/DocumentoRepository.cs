using System;
using Api1.Data.Models;
using Api1.Data.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace Api1.Data.Repository.ClienteRepository;

public class DocumentoRepository : BaseRepository,IQueryService<TypeDocument>
{
    public DocumentoRepository(DbBillingContext context): base(context)
    {
    }
    public async Task<bool> Update(TypeDocument document)
    {
        try
        {
            _context.Entry(document).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {

            throw new Exception("Error al actualizar el cliente", ex.GetBaseException());
        }
    }

    public async Task<bool> Create(TypeDocument document)
    {
        try
        {
            _context.TypeDocuments.Add(document);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {

            throw new Exception("Error al actualizar el cliente", ex.GetBaseException());
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var cliente = await _context.TypeDocuments.FindAsync(id);
            _context.TypeDocuments.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {

            throw new Exception("Error al eliminar el cliente", ex.GetBaseException());
        }
    }

    public async Task<TypeDocument> GetById(int id)
    {
        return await _context.TypeDocuments.FindAsync(id);
    }

    public IQueryable<TypeDocument> GetAll()
    {
        return _context.TypeDocuments.AsQueryable();
    }
}
