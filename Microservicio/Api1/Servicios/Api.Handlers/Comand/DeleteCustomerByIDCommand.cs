using System;
using MediatR;

namespace Api.Handler.Comand;

public class DeleteCustomerByIDCommand : IRequest<bool>
{
    public int Id { get; set; }
}
