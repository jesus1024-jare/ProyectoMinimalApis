using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Handlers.DTOs;

public class CustomerDTO
{
    [Required(ErrorMessage = "El campo nombre es requerido")]
    public string Name { get; set; } 
    [Required(ErrorMessage = "El campo documentotipo es requerido")]
    public int id_Type_Document { get; set; }
    [Required(ErrorMessage = "El campo documentonumero es requerido")]
    public int document_Number { get; set; }
    [Required(ErrorMessage = "El campo direccion es requerido")]
    public string? customer_Address { get; set; }
    [Required(ErrorMessage = "El campo phone es requerido")]
    public string? phone_Number { get; set; }
    [Required(ErrorMessage = "El campo correo es requerido")]
    public string? Email { get; set; }
}
