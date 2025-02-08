using System;
using Api.core.abstraction.Contracts;
using MediatR;

namespace Api.Handler.Comand;

public class DeleteDocumentByIDCommand : IRequest<bool>
{
    public int id { get; set; }
}
