using Api.core.abstraction.Contracts;
using Api.Handler.ClienteComand;
using Api1.Data.Models;
using Api1.Data.SqlServer;
using MediatR;

namespace Api.Handler.Handler;

public class CustomerCreateMethodHandler : BaseIRepository,IRequestHandler<CreateNewCustomerCommand, bool>
{
    public CustomerCreateMethodHandler(IRepository<Customer> customerRepository): base(customerRepository){
    }
    
    public async Task<bool> Handle(CreateNewCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var cliente = new Customer{
                NameCustomer = request.Data.Name,
                IdTypeDocument = request.Data.id_Type_Document,
                DocumentNumber = request.Data.document_Number,
                Address = request.Data.customer_Address,
                Phone = request.Data.phone_Number,
                Mail = request.Data.Email

            };
            await _customerRepository.Create(cliente);
            return true;
        }
        catch (Exception ex)
        {
            
            throw new Exception("Error al crear el cliente", ex.GetBaseException());
        }
    }
}
