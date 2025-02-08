using System;
using System.ComponentModel.DataAnnotations;
using Api.Handler.DTO;
using MediatR;

namespace Api.Handler.Comand;

public class CreateNewDocumentCommand : IRequest<bool>
{
    [Required]
    public TypeDocumentDTO Data { get; set; }
}
