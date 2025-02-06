namespace Api1.Data.Models
{
    public partial class Cliente
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int Tipodocumento { get; set; }

        public int NroDocumento { get; set; }

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }

        public string? Correo { get; set; }
    }
}