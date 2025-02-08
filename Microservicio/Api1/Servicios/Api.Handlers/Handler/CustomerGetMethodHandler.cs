using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api.core.abstraction.Contracts;
using Api.Handler.Comand;
using Api.Handlers.DTOs;
using Api1.Data.Models;
using Api1.Data.SqlServer;
using MediatR;

namespace Api.Handler.Handler
{
    public class CustomerGetMethodHandler : BaseIRepository ,IRequestHandler<GetClientCommand, List<CustomerDTO>>
    {
        public CustomerGetMethodHandler(IRepository<Customer> customerRepository): base(customerRepository){
    }


        public async Task<List<CustomerDTO>> Handle(GetClientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = _customerRepository.GetAll()
                    .Select(c => new CustomerDTO
                    {
                        Name = c.NameCustomer,
                        id_Type_Document = c.IdTypeDocument,
                        document_Number = c.DocumentNumber,
                        customer_Address = c.Address,
                        phone_Number = c.Phone,
                        Email = c.Mail
                    })
                    .ToList();

                return customer;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de clientes", ex);
            }
        }
    }
}
