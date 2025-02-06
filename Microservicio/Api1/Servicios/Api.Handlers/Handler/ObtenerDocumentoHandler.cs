using System;
using Api.Handler.Comand;
using Api.Handler.DTO;
using Api1.Data.Models;
using MediatR;

namespace Api.Handler.Handler;

public class ObtenerDocumentoHandler : IRequestHandler<ObtenerDocumentoCommand, List<DocumentoDTO>>
{
    IQueryService<Documento> documentoRepository;

    public ObtenerDocumentoHandler(IQueryService<Documento> documentoRepository){
        this.documentoRepository = documentoRepository;
    }

    public async Task<List<DocumentoDTO>> Handle(ObtenerDocumentoCommand request, CancellationToken cancellationToken)
    {
        try
            {
                var document = documentoRepository.ObtenerTodo()
                    .Select(c => new DocumentoDTO
                    {
                        IdTipoDocumento = c.IdTipoDocumento,
                        Nombre = c.Nombre
                    })
                    .ToList();

                return document;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de clientes", ex);
            }
    }
}
