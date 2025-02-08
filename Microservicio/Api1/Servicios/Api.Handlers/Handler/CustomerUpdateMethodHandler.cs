using Api.core.abstraction.Contracts;
using Api.Handler.Comand;
using Api1.Data.Models;
using Api1.Data.SqlServer;
using MediatR;

namespace Api.Handler.Handler
{
    public class CustomerUpdateMethodHandler : BaseIRepository ,IRequestHandler<UpdateCustomerByIDCommand, bool>
    {
        public CustomerUpdateMethodHandler(IRepository<Customer> customerRepository): base(customerRepository)
        {
        }
        public async Task<bool> Handle(UpdateCustomerByIDCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Verificar que request.Data no sea nulo
                if (request.Data == null)
                {
                    throw new ArgumentNullException(nameof(request.Data), "Los datos de actualización no pueden ser nulos.");
                }

                // Obtener el cliente existente
                var cliente = await _customerRepository.GetById(request.Id);
                if (cliente == null)
                {
                    throw new Exception($"No se encontró un cliente con el ID {request.Id}.");
                }

                // Actualizar las propiedades del cliente existente
                cliente.NameCustomer = request.Data.Name;
                cliente.IdTypeDocument = request.Data.id_Type_Document;
                cliente.DocumentNumber = request.Data.document_Number;
                cliente.Address = request.Data.customer_Address;
                cliente.Phone = request.Data.phone_Number;
                cliente.Mail = request.Data.Email;

                // Guardar los cambios en el repositorio
                await _customerRepository.Update(cliente);

                return true; // Actualización exitosa
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el cliente.", ex);
            }
        }
    }
}

