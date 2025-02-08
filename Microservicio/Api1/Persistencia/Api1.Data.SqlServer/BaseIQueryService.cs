using System;
using Api1.Data.Models;

namespace Api1.Data.SqlServer;

public class BaseIQueryService
{
    protected readonly IQueryService<TypeDocument> _documentRepository;

    public BaseIQueryService(IQueryService<TypeDocument> documentoRepository){
        _documentRepository = documentoRepository;
    }
}
