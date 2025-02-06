using Api.Handler.ClienteComand;
using Api.Handler.Comand;
using Asp.Versioning;
using Ejercicio.Helpers;
using MediatR;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
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

    // Filtro para mostrar solo los endpoints de la versión seleccionada
    options.DocInclusionPredicate((docName, apiDesc) =>
    {
        if (!apiDesc.TryGetMethodInfo(out var methodInfo)) return false;

        // Obtiene la versión de la API desde el atributo ApiVersion
        var version = methodInfo.DeclaringType?.GetCustomAttributes(true)
            .OfType<ApiVersionAttribute>()
            .SelectMany(attr => attr.Versions)
            .FirstOrDefault();

        // Si no tiene versión, se muestra en todas las versiones
        if (version == null) return true;

        // Compara la versión del método con la versión de la documentación solicitada
        return docName == $"v{version}";
    });
});

// Configurar el versionado de la API
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0); // Versión predeterminada
    options.ApiVersionReader = ApiVersionReader.Combine(
        new HeaderApiVersionReader("x-api-version"),
        new QueryStringApiVersionReader("api-version")
    );
});

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

// Version 1 de los endpoints
var v1 = app.MapGroup("/api/v1").WithTags("v1");
v1.MapPost("/CrearCliente", async (IMediator mediator, ClienteCommand command) =>
{
    var resultado = await mediator.Send(command);
    return resultado ? Results.Ok("Cliente creado correctamente") : Results.BadRequest("No se pudo crear el cliente");
});

v1.MapPost("/CrearDocumento", async (IMediator mediator, DocumentoCommand command) =>
{
    var resultado = await mediator.Send(command);
    return resultado ? Results.Ok("Documento creado correctamente") : Results.BadRequest("No se pudo crear el documento");
});

v1.MapDelete("/EliminarCliente/{id}", async (IMediator mediator, int id) =>
{
    var command = new IdEliminarCommand { Id = id };
    var resultado = await mediator.Send(command);
    return resultado ? Results.Ok("Cliente eliminado con éxito") : Results.NotFound("Cliente no encontrado");
});

v1.MapDelete("/EliminarDocumento/{id}", async (IMediator mediator, int id) =>
{
    var command = new IdEliminarDocumentoCommand { id = id };
    var resultado = await mediator.Send(command);
    return resultado ? Results.Ok("Documento eliminado con éxito") : Results.NotFound("Documento no encontrado");
});

// Version 2 de los endpoints
var v2 = app.MapGroup("/api/v2").WithTags("v2");
v2.MapPut("/ActualizarCliente/{Id}", async (IMediator mediator, IdActualizarCliente command) =>
{
    if (command.Data == null)
    {
        return Results.BadRequest("Los datos de actualización no pueden ser nulos.");
    }
    var resultado = await mediator.Send(command);
    return resultado ? Results.Ok("Cliente actualizado con éxito") : Results.NotFound("Cliente no encontrado");
});

v2.MapPut("/ActualizarDocumento/{Id}", async (IMediator mediator, IdActualizarDocumento command) =>
{
    if (command.Data == null)
    {
        return Results.BadRequest("Los datos de actualización no pueden ser nulos.");
    }
    var resultado = await mediator.Send(command);
    return resultado ? Results.Ok("Documento actualizado con éxito") : Results.NotFound("Documento no encontrado");
});

v2.MapGet("/ObtenerClientes", async (IMediator mediator) =>
{
    var query = new ObtenerClienteCommand(); 
    var clientes = await mediator.Send(query); 
    return Results.Ok(clientes); 
});

v2.MapGet("/ObtenerDocumento", async (IMediator mediator) =>
{
    var query = new ObtenerDocumentoCommand(); 
    var document = await mediator.Send(query); 
    return Results.Ok(document); 
});

app.Run();
