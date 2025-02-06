using System;
using System.Collections.Generic;

namespace Api1.Data.Models;

public partial class Documento
{
    public int IdTipoDocumento { get; set; }

    public string Nombre { get; set; } = null!;
}
