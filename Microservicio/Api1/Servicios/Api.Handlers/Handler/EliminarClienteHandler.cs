using Api.core.abstraction.Contracts;
using Api.Handler.Comand;
using Api1.Data.Models;
using MediatR;

namespace Api.Handler.Handler;

public class EliminarClienteHandler : IRequestHandler<IdEliminarCommand, bool>
{
    private readonly IRepository<Cliente> _clienteRepository;

    public EliminarClienteHandler(IRepository<Cliente> clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<bool> Handle(IdEliminarCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _clienteRepository.ObtenerPorId(request.Id);
        if (cliente == null)
        {
            return false; // Cliente no encontrado
        }

        // Eliminar el cliente
        await _clienteRepository.EliminarAsync(request.Id);
        return true;
    }
}