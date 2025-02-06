using Api.Handler.Comand;
using Api1.Data.Models;
using MediatR;

namespace Api.Handler.Handler;

public class CrearDocumentoHandler : IRequestHandler<DocumentoCommand, bool>
{   
    IQueryService<Documento> documentoRepository;

    public CrearDocumentoHandler(IQueryService<Documento> documentoRepository){
        this.documentoRepository = documentoRepository;
    }
    public async Task<bool> Handle(DocumentoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var document = new Documento{
                Nombre = request.Data.Nombre
            };
            await documentoRepository.Crear(document);
            return true;
        }
        catch (Exception ex)
        {
            
            throw new Exception("Error al crear el documento", ex.GetBaseException());
        }
    }
}
