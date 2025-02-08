using System;
using Api.core.abstraction.Contracts;
using Api1.Data.Models;

namespace Api1.Data.SqlServer;

public class BaseIRepository
{
    protected readonly IRepository<Customer> _customerRepository;

    public BaseIRepository(IRepository<Customer> clienteRepository){
        _customerRepository = clienteRepository;
    }
}
