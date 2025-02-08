using System;
using Api.Handlers.DTOs;
using MediatR;

namespace Api.Handler.Comand;

public class GetClientCommand : IRequest<List<CustomerDTO>>
{
}
