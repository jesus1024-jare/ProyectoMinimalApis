using System;
using System.ComponentModel.DataAnnotations;
using Api.core.abstraction.Contracts;
using Api.Handler.DTO;
using MediatR;

namespace Api.Handler.Comand;

public class UpdateDocumentByIDCommand : IRequest<bool>
{
    [Required]
    public TypeDocumentDTO Data { get; set; }

    public UpdateDocumentByIDCommand()
    {
        Data = new TypeDocumentDTO(); // Inicializa Data con un objeto vacío
    }
}
