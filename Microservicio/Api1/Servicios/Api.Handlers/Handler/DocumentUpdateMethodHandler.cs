using System;
using Api.Handler.Comand;
using Api1.Data.Models;
using Api1.Data.SqlServer;
using MediatR;

namespace Api.Handler.Handler;

public class ActualizarDocumentoHandler : BaseIQueryService,IRequestHandler<UpdateDocumentByIDCommand, bool>
{
    public ActualizarDocumentoHandler(IQueryService<TypeDocument> documentRepository): base(documentRepository){
    }

    public async Task<bool> Handle(UpdateDocumentByIDCommand request, CancellationToken cancellationToken)
    {
        try
            {
                // Verificar que request.Data no sea nulo
                if (request.Data == null)
                {
                    throw new ArgumentNullException(nameof(request.Data), "Los datos de actualización no pueden ser nulos.");
                }

                // Obtener el documento existente
                var document = await _documentRepository.GetById(request.Data.id_Type_Document);
                if (document == null)
                {
                    throw new Exception($"No se encontró un cliente con el ID {request.Data.id_Type_Document}.");
                }

                // Actualizar las propiedades del documento existente
                document.DocumentName = request.Data.document_type_name;

                // Guardar los cambios en el repositorio
                await _documentRepository.Update(document);

                return true; // Actualización exitosa
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el cliente.", ex);
            }
    }
}
