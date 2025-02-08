using System;
using Azure.Core.Pipeline;

namespace Api1.Data.SqlServer;

public class BaseRepository
{
    protected readonly DbBillingContext _context;
    public BaseRepository(DbBillingContext context)
    {
        _context = context;
    }
}
