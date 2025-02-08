using Api.core.abstraction.Contracts;
using Api1.Data.Models;
using Api1.Data.SqlServer;
using Microsoft.EntityFrameworkCore;

public class CustomerRepository : BaseRepository,IRepository<Customer>
{   
    public CustomerRepository(DbBillingContext context):base(context){
    }
    
    public async Task<bool> Update(Customer customer)
    {
        try
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            
            throw new Exception("Error al actualizar el cliente", ex.GetBaseException());
        }
    }

    public async Task<bool> Create(Customer customer)
    {
        try
        {
            _context.Customers.Add(customer);
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
            var cliente = await _context.Customers.FindAsync(id);
                _context.Customers.Remove(cliente);
                await _context.SaveChangesAsync();
                return true;
        }
        catch (Exception ex)
        {

            throw new Exception("Error al eliminar el cliente", ex.GetBaseException());
        }
    }

    public async Task<Customer> GetById(int id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public IQueryable<Customer> GetAll()
    {
        return _context.Customers.AsQueryable();
    }
}
