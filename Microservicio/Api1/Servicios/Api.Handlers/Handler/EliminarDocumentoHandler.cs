using System;
using Api.Handler.Comand;
using Api1.Data.Models;
using MediatR;

namespace Api.Handler.Handler;

public class EliminarDocumentoHandler : IRequestHandler<IdEliminarDocumentoCommand, bool>
{
    IQueryService<Documento> documentoRepository;

    public EliminarDocumentoHandler(IQueryService<Documento> documentoRepository){
        this.documentoRepository = documentoRepository;
    }

    public async Task<bool> Handle(IdEliminarDocumentoCommand request, CancellationToken cancellationToken)
    {
        var cliente = await documentoRepository.ObtenerPorId(request.id);
        if (cliente == null)
        {
            return false; // Cliente no encontrado
        }

        // Eliminar el cliente
        await documentoRepository.EliminarAsync(request.id);
        return true;
    }
}
