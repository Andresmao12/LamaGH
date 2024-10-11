using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LamaApp.Server.Models;

public partial class LamaSqlContext : DbContext
{
    public LamaSqlContext()
    {
    }

    public LamaSqlContext(DbContextOptions<LamaSqlContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Capitulo> Capitulos { get; set; }

    public virtual DbSet<Contacto> Contactos { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<Inscripcione> Inscripciones { get; set; }

    public virtual DbSet<Motocicleta> Motocicletas { get; set; }

    public virtual DbSet<Pareja> Parejas { get; set; }

    public virtual DbSet<Publicacione> Publicaciones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Capitulo>(entity =>
        {
            entity.HasKey(e => e.IdCapitulo);

            entity.Property(e => e.IdCapitulo).HasColumnName("ID_Capitulo");
        });

        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.HasKey(e => e.IdContacto);

            entity.Property(e => e.IdContacto).HasColumnName("ID_Contacto");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.IdEvento);

            entity.HasIndex(e => e.IdCapitulo, "IX_Eventos_ID_Capitulo");

            entity.Property(e => e.IdEvento).HasColumnName("ID_Evento");
            entity.Property(e => e.FechaFin).HasColumnName("Fecha_Fin");
            entity.Property(e => e.FechaInicio).HasColumnName("Fecha_Inicio");
            entity.Property(e => e.IdCapitulo).HasColumnName("ID_Capitulo");

            entity.HasOne(d => d.IdCapituloNavigation).WithMany(p => p.Eventos).HasForeignKey(d => d.IdCapitulo);
        });

        modelBuilder.Entity<Inscripcione>(entity =>
        {
            entity.HasKey(e => e.IdInscripcion);

            entity.HasIndex(e => e.IdEvento, "IX_Inscripciones_ID_Evento");

            entity.HasIndex(e => e.IdUsuario, "IX_Inscripciones_ID_Usuario");

            entity.Property(e => e.IdInscripcion).HasColumnName("ID_Inscripcion");
            entity.Property(e => e.FechaCompra).HasColumnName("Fecha_Compra");
            entity.Property(e => e.IdEvento).HasColumnName("ID_Evento");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.Inscripciones)
                .HasForeignKey(d => d.IdEvento)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Inscripciones)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Motocicleta>(entity =>
        {
            entity.HasKey(e => e.IdMotocicleta);

            entity.Property(e => e.IdMotocicleta).HasColumnName("ID_Motocicleta");
        });

        modelBuilder.Entity<Pareja>(entity =>
        {
            entity.HasKey(e => e.IdPareja);

            entity.Property(e => e.IdPareja).HasColumnName("ID_Pareja");
        });

        modelBuilder.Entity<Publicacione>(entity =>
        {
            entity.HasKey(e => e.IdPublicacion);

            entity.HasIndex(e => e.IdUsuario, "IX_Publicaciones_ID_Usuario");

            entity.Property(e => e.IdPublicacion).HasColumnName("ID_Publicacion");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Publicaciones).HasForeignKey(d => d.IdUsuario);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.HasIndex(e => e.IdCapitulo, "IX_Usuarios_ID_Capitulo");

            entity.Property(e => e.IdUsuario)
                .ValueGeneratedNever()
                .HasColumnName("ID_Usuario");
            entity.Property(e => e.FechaNacimiento).HasColumnName("Fecha_Nacimiento");
            entity.Property(e => e.FechaRegistro).HasColumnName("Fecha_Registro");
            entity.Property(e => e.IdCapitulo).HasColumnName("ID_Capitulo");
            entity.Property(e => e.IdContacto).HasColumnName("ID_Contacto");
            entity.Property(e => e.IdMotocicleta).HasColumnName("ID_Motocicleta");
            entity.Property(e => e.IdPareja).HasColumnName("ID_Pareja");
            entity.Property(e => e.NombreUsuario).HasColumnName("Nombre_Usuario");

            entity.HasOne(d => d.IdCapituloNavigation).WithMany(p => p.Usuarios).HasForeignKey(d => d.IdCapitulo);

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.Usuario).HasForeignKey<Usuario>(d => d.IdUsuario);

            entity.HasOne(d => d.IdUsuario1).WithOne(p => p.Usuario).HasForeignKey<Usuario>(d => d.IdUsuario);

            entity.HasOne(d => d.IdUsuario2).WithOne(p => p.Usuario).HasForeignKey<Usuario>(d => d.IdUsuario);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
