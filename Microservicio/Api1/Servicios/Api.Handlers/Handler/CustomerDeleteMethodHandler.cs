using Api.core.abstraction.Contracts;
using Api.Handler.Comand;
using Api1.Data.Models;
using Api1.Data.SqlServer;
using MediatR;

namespace Api.Handler.Handler;

public class CustomerDeleteMethodHandler :BaseIRepository ,IRequestHandler<DeleteCustomerByIDCommand, bool>
{
    public CustomerDeleteMethodHandler(IRepository<Customer> customerRepository): base(customerRepository){
    }
    public async Task<bool> Handle(DeleteCustomerByIDCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetById(request.Id);
        if (customer == null)
        {
            return false; // Cliente no encontrado
        }

        // Eliminar el cliente
        await _customerRepository.DeleteAsync(request.Id);
        return true;
    }
}