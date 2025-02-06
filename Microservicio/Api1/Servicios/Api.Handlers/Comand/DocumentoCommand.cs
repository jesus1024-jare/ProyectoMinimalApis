using System;
using System.ComponentModel.DataAnnotations;
using Api.Handler.DTO;
using MediatR;

namespace Api.Handler.Comand;

public class DocumentoCommand : IRequest<bool>
{
    [Required]
    public DocumentoDTO Data { get; set; }
}
