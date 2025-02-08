using System;
using System.ComponentModel.DataAnnotations;
using Api.Handlers.DTOs;
using MediatR;

namespace Api.Handler.Comand;

public class UpdateCustomerByIDCommand : IRequest<bool>
{
    [Required]
    public int Id { get; set; }
    [Required]
    public CustomerDTO Data {get; set;} = default!;

    public UpdateCustomerByIDCommand()
    {
        Data = new CustomerDTO(); // Inicializa Data con un objeto vacío
    }
}
