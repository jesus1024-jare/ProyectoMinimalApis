using Api.core.abstraction.Contracts;
using Api.Handler.ClienteComand;
using Api1.Data.Models;
using Api1.Data.SqlServer;
using MediatR;

namespace Api.Handler.Handler;

public class CrearClientesHandlers : IRequestHandler<ClienteCommand, bool>
{
    IRepository<Cliente> clienteRepository;

    public CrearClientesHandlers(IRepository<Cliente> clienteRepository){
        this.clienteRepository = clienteRepository;
    }
    public async Task<bool> Handle(ClienteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var cliente = new Cliente{
                Name = request.Data.Name,
                Tipodocumento = request.Data.Tipodocumento,
                NroDocumento = request.Data.NroDocumento,
                Direccion = request.Data.Direccion,
                Telefono = request.Data.Telefono,
                Correo = request.Data.Correo

            };
            await clienteRepository.Crear(cliente);
            return true;
        }
        catch (Exception ex)
        {
            
            throw new Exception("Error al crear el cliente", ex.GetBaseException());
        }
    }
}
