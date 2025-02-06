using System;
using System.Collections.Generic;
using Api1.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Api1.Data.SqlServer;

public partial class DbFacturacion : DbContext
{
    public DbFacturacion()
    {
    }

    public DbFacturacion(DbContextOptions<DbFacturacion> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Documento> Documentos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Models;User Id=sa;Password=Jare2329P@;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__clientes__3214EC0720B872DA");

            entity.ToTable("clientes");

            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.Tipodocumento).HasColumnName("tipodocumento");
        });

        modelBuilder.Entity<Documento>(entity =>
        {
            entity.HasKey(e => e.IdTipoDocumento).HasName("PK_Documento");

            entity.ToTable("documento");

            entity.Property(e => e.IdTipoDocumento).HasColumnName("Id_Tipo_Documento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
