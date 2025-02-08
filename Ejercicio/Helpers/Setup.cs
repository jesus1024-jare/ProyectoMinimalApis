using Api.core.abstraction.Contracts;
using Api.Handler.ClienteComand;
using Api.Handler.Comand;
using Api1.Data.Models;
using Api1.Data.Repository.ClienteRepository;
using Api1.Data.SqlServer;
using Ejercicio.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio.Helpers
{
    public static class Setup
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            var connectionStringsSection = builder.Configuration.GetSection(nameof(ApplicationSettings));


            //inyección de dependencias para ConnectionStrings
            builder.Services.Configure<ApplicationSettings>(connectionStringsSection);

            // instancia de ConnectionStrings
            var connectionStrings = connectionStringsSection.Get<ApplicationSettings>();

            builder.Services.AddDbContext<DbBillingContext>(options => {
                options.UseSqlServer(connectionStrings!.ConnectionStrings);
            }
            );
            builder.Services.AddMediatR(options => options.RegisterServicesFromAssembly(typeof(CreateNewCustomerCommand).Assembly));
            builder.Services.AddMediatR(options => options.RegisterServicesFromAssembly(typeof(CreateNewDocumentCommand).Assembly));
            builder.Services.AddMediatR(options => options.RegisterServicesFromAssembly(typeof(DeleteCustomerByIDCommand).Assembly));
            builder.Services.AddMediatR(options => options.RegisterServicesFromAssembly(typeof(DeleteDocumentByIDCommand).Assembly));
            builder.Services.AddMediatR(options => options.RegisterServicesFromAssembly(typeof(UpdateCustomerByIDCommand).Assembly));
            builder.Services.AddMediatR(options => options.RegisterServicesFromAssembly(typeof(UpdateDocumentByIDCommand).Assembly));
            builder.Services.AddTransient<IRepository<Customer>, CustomerRepository>();
            builder.Services.AddTransient<IQueryService<TypeDocument>, DocumentoRepository>();
        }   
    }
}