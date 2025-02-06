 using Api.Handler.ClienteComand;
using Api.Handler.Comand;
using Ejercicio.Helpers;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar DbContext
Setup.Configure(builder);

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/CrearCliente", async (IMediator mediator, ClienteCommand command) =>
{
    var resultado = await mediator.Send(command);
    return resultado ? Results.Ok("Cliente creado correctamente") : Results.BadRequest("No se pudo crear el cliente");
});

app.MapPost("/CrearDocumento", async (IMediator mediator, DocumentoCommand command) =>
{
    var resultado = await mediator.Send(command);
    return resultado ? Results.Ok("Documento creado correctamente") : Results.BadRequest("No se pudo crear el documento");
});

app.MapDelete("/EliminarCliente/{id}", async (IMediator mediator, int id) =>
{
    var command = new IdEliminarCommand { Id = id };
    var resultado = await mediator.Send(command);
    return resultado ? Results.Ok("Cliente eliminado con éxito") : Results.NotFound("Cliente no encontrado");
});

app.MapDelete("/EliminarDocumento/{id}", async (IMediator mediator, int id) =>
{
    var command = new IdEliminarDocumentoCommand { id = id };
    var resultado = await mediator.Send(command);
    return resultado ? Results.Ok("Documento eliminado con éxito") : Results.NotFound("Documento no encontrado");
});

app.MapPut("/ActualizarCliente/{Id}", async (IMediator mediator, IdActualizarCliente command) =>
{
    // Verificar que command.Data no sea nulo
    if (command.Data == null)
    {
        return Results.BadRequest("Los datos de actualización no pueden ser nulos.");
    }

    // Enviar la solicitud al manejador
    var resultado = await mediator.Send(command);

    // Devolver la respuesta adecuada
    return resultado ? Results.Ok("Cliente actualizado con éxito") : Results.NotFound("Cliente no encontrado");
});

app.MapPut("/ActualizarDocumento/{Id}", async (IMediator mediator, IdActualizarDocumento command) =>
{
    // Verificar que command.Data no sea nulo
    if (command.Data == null)
    {
        return Results.BadRequest("Los datos de actualización no pueden ser nulos.");
    }

    // Enviar la solicitud al manejador
    var resultado = await mediator.Send(command);

    // Devolver la respuesta adecuada
    return resultado ? Results.Ok("Cliente actualizado con éxito") : Results.NotFound("Cliente no encontrado");
});


app.MapGet("/ObtenerClientes", async (IMediator mediator) =>
{
    var query = new ObtenerClienteCommand(); 
    var clientes = await mediator.Send(query); // Enviar la consulta a MediatR
    return Results.Ok(clientes); // Retornar la lista de clientes
});

app.MapGet("/ObtenerDocumento", async (IMediator mediator) =>
{
    var query = new ObtenerDocumentoCommand(); 
    var document = await mediator.Send(query); // Enviar la consulta a MediatR
    return Results.Ok(document); // Retornar la lista de clientes
});

app.Run();