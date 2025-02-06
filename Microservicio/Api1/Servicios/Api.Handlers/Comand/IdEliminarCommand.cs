using System;
using MediatR;

namespace Api.Handler.Comand;

public class IdEliminarCommand : IRequest<bool>
{
    public int Id { get; set; }
}
