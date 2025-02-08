using Api.Handler.ClienteComand;
using Api.Handler.Comand;
using Asp.Versioning;
using Asp.Versioning.Builder;
using Ejercicio.Helpers;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddEndpointsApiExplorer();
/* builder.Services.AddSwaggerGen(options =>
{
    // Configuración para múltiples versiones de la API
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API v1",
        Version = "v1"
    });
    options.SwaggerDoc("v2", new OpenApiInfo
    {
        Title = "API v2",
        Version = "v2"
    });

    options.DocInclusionPredicate((docName, apiDesc) =>
    {
        if (!apiDesc.TryGetMethodInfo(out var methodInfo)) return false;

        var version = methodInfo.DeclaringType?.GetCustomAttributes(true)
            .OfType<ApiVersionAttribute>()
            .SelectMany(attr => attr.Versions)
            .FirstOrDefault();
        if (version == null) return true;

        return docName == $"v{version}";
    });
});
 */

builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;  
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("X-Api-Version"),
        new QueryStringApiVersionReader("api-version")
    );
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V";
    options.SubstituteApiVersionInUrl = true;
})
.AddMvc();

// Configurar DbContext
Setup.Configure(builder);

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        // Configura los endpoints Swagger para las versiones
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "API v2");

        // Esto permite la selección de la versión en el Swagger UI
        options.DefaultModelsExpandDepth(-1);
        options.DocumentTitle = "API - Versiones v1 y v2"; // Título en el UI de Swagger
    });
}

app.UseHttpsRedirection();

ApiVersionSet listaVersionesApi = app.NewApiVersionSet()
.HasApiVersion(new ApiVersion(1, 0))
.ReportApiVersions()
.Build();

// Version 1 de los endpoints
var grupoVersiones = app.MapGroup("/api/v{version:apiVersion}")
.WithApiVersionSet(listaVersionesApi);


grupoVersiones.MapPost("Customer", async (IMediator mediator, CreateNewCustomerCommand command) =>
{
    var resultado = await mediator.Send(command);
    return resultado ? Results.Ok("Cliente creado correctamente") : Results.BadRequest("No se pudo crear el cliente");
});

grupoVersiones.MapPost("Document", async (IMediator mediator, CreateNewDocumentCommand command) =>
{
    var resultado = await mediator.Send(command);
    return resultado ? Results.Ok("Documento creado correctamente") : Results.BadRequest("No se pudo crear el documento");
});

grupoVersiones.MapDelete("Customer/{id}", async (IMediator mediator, int id) =>
{
    var command = new DeleteCustomerByIDCommand { Id = id };
    var resultado = await mediator.Send(command);
    return resultado ? Results.Ok("Cliente eliminado con éxito") : Results.NotFound("Cliente no encontrado");
});

grupoVersiones.MapDelete("Document/{id}", async (IMediator mediator, int id) =>
{
    var command = new DeleteDocumentByIDCommand { id = id };
    var resultado = await mediator.Send(command);
    return resultado ? Results.Ok("Documento eliminado con éxito") : Results.NotFound("Documento no encontrado");
});


grupoVersiones.MapPut("Customer/{Id}", async (IMediator mediator, UpdateCustomerByIDCommand command) =>
{
    if (command.Data == null)
    {
        return Results.BadRequest("Los datos de actualización no pueden ser nulos.");
    }
    var resultado = await mediator.Send(command);
    return resultado ? Results.Ok("Cliente actualizado con éxito") : Results.NotFound("Cliente no encontrado");
});

grupoVersiones.MapPut("Document/{Id}", async (IMediator mediator, UpdateDocumentByIDCommand command) =>
{
    if (command.Data == null)
    {
        return Results.BadRequest("Los datos de actualización no pueden ser nulos.");
    }
    var resultado = await mediator.Send(command);
    return resultado ? Results.Ok("Documento actualizado con éxito") : Results.NotFound("Documento no encontrado");
});

grupoVersiones.MapGet("Customer", async (IMediator mediator) =>
{
    var query = new GetClientCommand();
    var clientes = await mediator.Send(query);
    return Results.Ok(clientes);
});

grupoVersiones.MapGet("Document", async (IMediator mediator) =>
{
    var query = new GetDocumentCommand();
    var document = await mediator.Send(query);
    return Results.Ok(document);
});

app.Run();
