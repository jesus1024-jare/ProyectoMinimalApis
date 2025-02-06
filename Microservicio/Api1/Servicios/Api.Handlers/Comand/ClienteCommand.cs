using System.ComponentModel.DataAnnotations;
using Api.Handlers.DTOs;
using MediatR;

namespace Api.Handler.ClienteComand
{
    public class ClienteCommand : IRequest<bool>
    {
        [Required]
        public ClienteDTO Data {get; set;} = default!;
    }
}