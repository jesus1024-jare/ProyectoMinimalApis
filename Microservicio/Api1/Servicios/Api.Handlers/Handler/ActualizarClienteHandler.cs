using Api.core.abstraction.Contracts;
using Api.Handler.Comand;
using Api1.Data.Models;
using MediatR;

namespace Api.Handler.Handler
{
    public class ActualizarClienteHandler : IRequestHandler<IdActualizarCliente, bool>
    {
        private readonly IRepository<Cliente> _clienteRepository;

        public ActualizarClienteHandler(IRepository<Cliente> clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public async Task<bool> Handle(IdActualizarCliente request, CancellationToken cancellationToken)
        {
            try
            {
                // Verificar que request.Data no sea nulo
                if (request.Data == null)
                {
                    throw new ArgumentNullException(nameof(request.Data), "Los datos de actualización no pueden ser nulos.");
                }

                // Obtener el cliente existente
                var cliente = await _clienteRepository.ObtenerPorId(request.Id);
                if (cliente == null)
                {
                    throw new Exception($"No se encontró un cliente con el ID {request.Id}.");
                }

                // Actualizar las propiedades del cliente existente
                cliente.Name = request.Data.Name;
                cliente.Tipodocumento = request.Data.Tipodocumento;
                cliente.NroDocumento = request.Data.NroDocumento;
                cliente.Direccion = request.Data.Direccion;
                cliente.Telefono = request.Data.Telefono;
                cliente.Correo = request.Data.Correo;

                // Guardar los cambios en el repositorio
                await _clienteRepository.Actualizar(cliente);

                return true; // Actualización exitosa
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el cliente.", ex);
            }
        }
    }
}

