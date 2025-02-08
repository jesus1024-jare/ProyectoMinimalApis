using System;
using Api.Handler.Comand;
using Api1.Data.Models;
using Api1.Data.SqlServer;
using MediatR;

namespace Api.Handler.Handler;

public class DocumentDeleteMethodHandler : BaseIQueryService,IRequestHandler<DeleteDocumentByIDCommand, bool>
{
    public DocumentDeleteMethodHandler(IQueryService<TypeDocument> documentRepository):base(documentRepository){
    }

    public async Task<bool> Handle(DeleteDocumentByIDCommand request, CancellationToken cancellationToken)
    {
        var document = await _documentRepository.GetById(request.id);
        if (document == null)
        {
            return false; // Cliente no encontrado
        }

        // Eliminar el cliente
        await _documentRepository.DeleteAsync(request.id);
        return true;
    }
}
