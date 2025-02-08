using System.ComponentModel.DataAnnotations;
using Api.Handlers.DTOs;
using MediatR;

namespace Api.Handler.ClienteComand
{
    public class CreateNewCustomerCommand : IRequest<bool>
    {
        [Required]
        public CustomerDTO Data {get; set;} = default!;
    }
}