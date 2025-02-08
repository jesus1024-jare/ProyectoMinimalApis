using System;
using Api.Handler.Comand;
using Api.Handler.DTO;
using Api1.Data.Models;
using Api1.Data.SqlServer;
using MediatR;

namespace Api.Handler.Handler;

public class DocumentGetMethodHandler : BaseIQueryService ,IRequestHandler<GetDocumentCommand, List<TypeDocumentDTO>>
{
    public DocumentGetMethodHandler(IQueryService<TypeDocument> documentRepository):base(documentRepository){
    }

    public async Task<List<TypeDocumentDTO>> Handle(GetDocumentCommand request, CancellationToken cancellationToken)
    {
        try
            {
                var document = _documentRepository.GetAll()
                    .Select(c => new TypeDocumentDTO
                    {
                        id_Type_Document = c.IdTypeDocument,
                        document_type_name = c.DocumentName
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
