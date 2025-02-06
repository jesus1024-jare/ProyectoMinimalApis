using System;
using System.ComponentModel.DataAnnotations;
using Api.Handlers.DTOs;
using MediatR;

namespace Api.Handler.Comand;

public class IdActualizarCliente : IRequest<bool>
{
    [Required]
    public int Id { get; set; }
    [Required]
    public ClienteDTO Data {get; set;} = default!;

    public IdActualizarCliente()
    {
        Data = new ClienteDTO(); // Inicializa Data con un objeto vacío
    }
}
