using System;
using System.ComponentModel.DataAnnotations;
using Api.core.abstraction.Contracts;
using Api.Handler.DTO;
using MediatR;

namespace Api.Handler.Comand;

public class IdActualizarDocumento : IRequest<bool>
{
    [Required]
    public DocumentoDTO Data { get; set; }

    public IdActualizarDocumento()
    {
        Data = new DocumentoDTO(); // Inicializa Data con un objeto vacío
    }
}
