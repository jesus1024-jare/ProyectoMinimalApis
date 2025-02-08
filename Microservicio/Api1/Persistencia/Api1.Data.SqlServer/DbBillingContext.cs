using System;
using System.Collections.Generic;
using Api1.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Api1.Data.SqlServer;

public partial class DbBillingContext : DbContext
{
    public DbBillingContext()
    {
    }

    public DbBillingContext(DbContextOptions<DbBillingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<TypeDocument> TypeDocuments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=db_Billing;User Id=sa;Password=Jare2329P@;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.IdCustomer).HasName("PK__Customer__5D5E9BAA39EAC040");

            entity.ToTable("Customer");

            entity.Property(e => e.IdCustomer).HasColumnName("id_Customer");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.DocumentNumber).HasColumnName("document_Number");
            entity.Property(e => e.IdTypeDocument).HasColumnName("id_Type_Document");
            entity.Property(e => e.Mail).HasMaxLength(100);
            entity.Property(e => e.NameCustomer)
                .HasMaxLength(100)
                .HasColumnName("name_Customer");
            entity.Property(e => e.Phone).HasMaxLength(50);

            entity.HasOne(d => d.IdTypeDocumentNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.IdTypeDocument)
                .HasConstraintName("FK_Customer_Type_Document");
        });

        modelBuilder.Entity<TypeDocument>(entity =>
        {
            entity.HasKey(e => e.IdTypeDocument).HasName("PK__Type_Doc__7F278D07C2CB9007");

            entity.ToTable("Type_Document");

            entity.Property(e => e.IdTypeDocument).HasColumnName("id_Type_Document");
            entity.Property(e => e.DocumentName)
                .HasMaxLength(100)
                .HasColumnName("document_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
