﻿// <auto-generated />
using System;
using LamaApp.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LamaApp.Server.Migrations
{
    [DbContext(typeof(LamaSqlContext))]
    [Migration("20241101023315_atributosContenidoImgPublicacion")]
    partial class atributosContenidoImgPublicacion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LamaApp.Server.Models.Capitulo", b =>
                {
                    b.Property<int>("IdCapitulo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Capitulo");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCapitulo"));

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCapitulo");

                    b.ToTable("Capitulo");
                });

            modelBuilder.Entity("LamaApp.Server.Models.Contacto", b =>
                {
                    b.Property<int>("IdContacto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Contacto");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdContacto"));

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdContacto");

                    b.ToTable("Contacto");
                });

            modelBuilder.Entity("LamaApp.Server.Models.Evento", b =>
                {
                    b.Property<int>("IdEvento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Evento");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEvento"));

                    b.Property<string>("Creador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2")
                        .HasColumnName("Fecha_Fin");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2")
                        .HasColumnName("Fecha_Inicio");

                    b.Property<int>("IdCapitulo")
                        .HasColumnType("int")
                        .HasColumnName("ID_Capitulo");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEvento");

                    b.HasIndex(new[] { "IdCapitulo" }, "IX_Eventos_ID_Capitulo");

                    b.ToTable("Evento");
                });

            modelBuilder.Entity("LamaApp.Server.Models.Inscripcion", b =>
                {
                    b.Property<int>("IdInscripcion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Inscripcion");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInscripcion"));

                    b.Property<DateTime>("FechaCompra")
                        .HasColumnType("datetime2")
                        .HasColumnName("Fecha_Compra");

                    b.Property<int>("IdEvento")
                        .HasColumnType("int")
                        .HasColumnName("ID_Evento");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int")
                        .HasColumnName("ID_Usuario");

                    b.HasKey("IdInscripcion");

                    b.HasIndex(new[] { "IdEvento" }, "IX_Inscripciones_ID_Evento");

                    b.HasIndex(new[] { "IdUsuario" }, "IX_Inscripciones_ID_Usuario");

                    b.ToTable("Inscripcion");
                });

            modelBuilder.Entity("LamaApp.Server.Models.Motocicleta", b =>
                {
                    b.Property<int>("IdMotocicleta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Motocicleta");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMotocicleta"));

                    b.Property<int>("Cilindrada")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMotocicleta");

                    b.ToTable("Motocicleta");
                });

            modelBuilder.Entity("LamaApp.Server.Models.Pareja", b =>
                {
                    b.Property<int>("IdPareja")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Pareja");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPareja"));

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPareja");

                    b.ToTable("Pareja");
                });

            modelBuilder.Entity("LamaApp.Server.Models.Publicacion", b =>
                {
                    b.Property<int>("IdPublicacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Publicacion");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPublicacion"));

                    b.Property<string>("Contenido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int")
                        .HasColumnName("ID_Usuario");

                    b.Property<int>("numeroLikes")
                        .HasColumnType("int");

                    b.Property<string>("urlImagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPublicacion");

                    b.HasIndex(new[] { "IdUsuario" }, "IX_Publicaciones_ID_Usuario");

                    b.ToTable("Publicacion");
                });

            modelBuilder.Entity("LamaApp.Server.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Usuario");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Apellido");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Cedula");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2")
                        .HasColumnName("Fecha_Nacimiento");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2")
                        .HasColumnName("Fecha_Registro");

                    b.Property<int>("IdCapitulo")
                        .HasColumnType("int")
                        .HasColumnName("ID_Capitulo");

                    b.Property<int?>("IdContacto")
                        .HasColumnType("int")
                        .HasColumnName("ID_Contacto");

                    b.Property<int?>("IdMotocicleta")
                        .HasColumnType("int")
                        .HasColumnName("ID_Motocicleta");

                    b.Property<int?>("IdPareja")
                        .HasColumnType("int")
                        .HasColumnName("ID_Pareja");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Nombre");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nombre_Usuario");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdContacto")
                        .IsUnique()
                        .HasFilter("[ID_Contacto] IS NOT NULL");

                    b.HasIndex("IdMotocicleta")
                        .IsUnique()
                        .HasFilter("[ID_Motocicleta] IS NOT NULL");

                    b.HasIndex("IdPareja")
                        .IsUnique()
                        .HasFilter("[ID_Pareja] IS NOT NULL");

                    b.HasIndex(new[] { "IdCapitulo" }, "IX_Usuarios_ID_Capitulo");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("LamaApp.Server.Models.Evento", b =>
                {
                    b.HasOne("LamaApp.Server.Models.Capitulo", "Capitulo")
                        .WithMany("Eventos")
                        .HasForeignKey("IdCapitulo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Capitulo");
                });

            modelBuilder.Entity("LamaApp.Server.Models.Inscripcion", b =>
                {
                    b.HasOne("LamaApp.Server.Models.Evento", "Evento")
                        .WithMany("Inscripciones")
                        .HasForeignKey("IdEvento")
                        .IsRequired();

                    b.HasOne("LamaApp.Server.Models.Usuario", "Usuario")
                        .WithMany("Inscripciones")
                        .HasForeignKey("IdUsuario")
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("LamaApp.Server.Models.Publicacion", b =>
                {
                    b.HasOne("LamaApp.Server.Models.Usuario", "Usuario")
                        .WithMany("Publicaciones")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("LamaApp.Server.Models.Usuario", b =>
                {
                    b.HasOne("LamaApp.Server.Models.Capitulo", "Capitulo")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdCapitulo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LamaApp.Server.Models.Contacto", "Contacto")
                        .WithOne("Usuario")
                        .HasForeignKey("LamaApp.Server.Models.Usuario", "IdContacto");

                    b.HasOne("LamaApp.Server.Models.Motocicleta", "Motocicleta")
                        .WithOne("Usuario")
                        .HasForeignKey("LamaApp.Server.Models.Usuario", "IdMotocicleta");

                    b.HasOne("LamaApp.Server.Models.Pareja", "Pareja")
                        .WithOne("Usuario")
                        .HasForeignKey("LamaApp.Server.Models.Usuario", "IdPareja");

                    b.Navigation("Capitulo");

                    b.Navigation("Contacto");

                    b.Navigation("Motocicleta");

                    b.Navigation("Pareja");
                });

            modelBuilder.Entity("LamaApp.Server.Models.Capitulo", b =>
                {
                    b.Navigation("Eventos");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("LamaApp.Server.Models.Contacto", b =>
                {
                    b.Navigation("Usuario")
                        .IsRequired();
                });

            modelBuilder.Entity("LamaApp.Server.Models.Evento", b =>
                {
                    b.Navigation("Inscripciones");
                });

            modelBuilder.Entity("LamaApp.Server.Models.Motocicleta", b =>
                {
                    b.Navigation("Usuario")
                        .IsRequired();
                });

            modelBuilder.Entity("LamaApp.Server.Models.Pareja", b =>
                {
                    b.Navigation("Usuario")
                        .IsRequired();
                });

            modelBuilder.Entity("LamaApp.Server.Models.Usuario", b =>
                {
                    b.Navigation("Inscripciones");

                    b.Navigation("Publicaciones");
                });
#pragma warning restore 612, 618
        }
    }
}
