using System;
using Api.Handlers.DTOs;
using MediatR;

namespace Api.Handler.Comand;

public class ObtenerClienteCommand : IRequest<List<ClienteDTO>>
{
}
