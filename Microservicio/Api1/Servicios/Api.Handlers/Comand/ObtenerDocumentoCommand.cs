using System;
using Api.Handler.DTO;
using MediatR;

namespace Api.Handler.Comand;

public class ObtenerDocumentoCommand : IRequest<List<DocumentoDTO>>
{

}
