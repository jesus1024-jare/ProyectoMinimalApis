using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api.core.abstraction.Contracts;
using Api.Handler.Comand;
using Api.Handlers.DTOs;
using Api1.Data.Models;
using MediatR;

namespace Api.Handler.Handler
{
    public class ObtenerClientesHandler : IRequestHandler<ObtenerClienteCommand, List<ClienteDTO>>
    {
        private readonly IRepository<Cliente> _clienteRepository;

        public ObtenerClientesHandler(IRepository<Cliente> clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<List<ClienteDTO>> Handle(ObtenerClienteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var clientes = _clienteRepository.ObtenerTodo()
                    .Select(c => new ClienteDTO
                    {
                        Name = c.Name,
                        Tipodocumento = c.Tipodocumento,
                        NroDocumento = c.NroDocumento,
                        Direccion = c.Direccion,
                        Telefono = c.Telefono,
                        Correo = c.Correo
                    })
                    .ToList();

                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de clientes", ex);
            }
        }
    }
}
