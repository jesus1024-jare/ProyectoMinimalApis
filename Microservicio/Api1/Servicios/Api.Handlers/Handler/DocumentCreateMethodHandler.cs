using Api.Handler.Comand;
using Api1.Data.Models;
using Api1.Data.SqlServer;
using MediatR;

namespace Api.Handler.Handler;

public class DocumentCreateMethodHandler : BaseIQueryService,IRequestHandler<CreateNewDocumentCommand, bool>
{
    public DocumentCreateMethodHandler(IQueryService<TypeDocument> documentRepository): base(documentRepository){
    }
    public async Task<bool> Handle(CreateNewDocumentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var document = new TypeDocument{
                DocumentName = request.Data.document_type_name
            };
            await _documentRepository.Create(document);
            return true;
        }
        catch (Exception ex)
        {
            
            throw new Exception("Error al crear el documento", ex.GetBaseException());
        }
    }
}
