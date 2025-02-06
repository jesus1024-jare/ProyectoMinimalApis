using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Handlers.DTOs;

public class ClienteDTO
{
    [Required(ErrorMessage = "El campo nombre es requerido")]
    public string Name { get; set; } 
    [Required(ErrorMessage = "El campo documentotipo es requerido")]
    public int Tipodocumento { get; set; }
    [Required(ErrorMessage = "El campo documentonumero es requerido")]
    public int NroDocumento { get; set; }
    [Required(ErrorMessage = "El campo direccion es requerido")]
    public string? Direccion { get; set; }
    [Required(ErrorMessage = "El campo phone es requerido")]
    public string? Telefono { get; set; }
    [Required(ErrorMessage = "El campo correo es requerido")]
    public string? Correo { get; set; }
}
