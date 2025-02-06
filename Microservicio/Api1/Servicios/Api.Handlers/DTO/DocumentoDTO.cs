using System;

namespace Api.Handler.DTO;

public class DocumentoDTO
{
    public int IdTipoDocumento { get; set; }

    public string Nombre { get; set; } = null!;
}
