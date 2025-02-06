using System;
using Api.Handler.Comand;
using Api1.Data.Models;
using MediatR;

namespace Api.Handler.Handler;

public class ActualizarDocumentoHandler : IRequestHandler<IdActualizarDocumento, bool>
{
    IQueryService<Documento> documentoRepository;

    public ActualizarDocumentoHandler(IQueryService<Documento> documentoRepository){
        this.documentoRepository = documentoRepository;
    }

    public async Task<bool> Handle(IdActualizarDocumento request, CancellationToken cancellationToken)
    {
        try
            {
                // Verificar que request.Data no sea nulo
                if (request.Data == null)
                {
                    throw new ArgumentNullException(nameof(request.Data), "Los datos de actualización no pueden ser nulos.");
                }

                // Obtener el documento existente
                var document = await documentoRepository.ObtenerPorId(request.Data.IdTipoDocumento);
                if (document == null)
                {
                    throw new Exception($"No se encontró un cliente con el ID {request.Data.IdTipoDocumento}.");
                }

                // Actualizar las propiedades del documento existente
                document.Nombre = request.Data.Nombre;

                // Guardar los cambios en el repositorio
                await documentoRepository.Actualizar(document);

                return true; // Actualización exitosa
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el cliente.", ex);
            }
    }
}
