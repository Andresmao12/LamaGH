﻿// <auto-generated />
using System;
using LamaAppVS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LamaAppVS.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LamaAppVS.Shared.Models.Capitulo", b =>
                {
                    b.Property<int>("ID_Capitulo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Capitulo"));

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Capitulo");

                    b.ToTable("Capitulos");
                });

            modelBuilder.Entity("LamaAppVS.Shared.Models.Contacto", b =>
                {
                    b.Property<int>("ID_Contacto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Contacto"));

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Direccion")
                        .HasColumnType("int");

                    b.HasKey("ID_Contacto");

                    b.ToTable("Contactos");
                });

            modelBuilder.Entity("LamaAppVS.Shared.Models.Evento", b =>
                {
                    b.Property<int>("ID_Evento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Evento"));

                    b.Property<string>("Creador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha_Fin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_Inicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("ID_Capitulo")
                        .HasColumnType("int");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Evento");

                    b.HasIndex("ID_Capitulo");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("LamaAppVS.Shared.Models.Inscripcion", b =>
                {
                    b.Property<int>("ID_Inscripcion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Inscripcion"));

                    b.Property<DateTime>("Fecha_Compra")
                        .HasColumnType("datetime2");

                    b.Property<int>("ID_Evento")
                        .HasColumnType("int");

                    b.Property<int>("ID_Usuario")
                        .HasColumnType("int");

                    b.HasKey("ID_Inscripcion");

                    b.HasIndex("ID_Evento");

                    b.HasIndex("ID_Usuario");

                    b.ToTable("Inscripciones");
                });

            modelBuilder.Entity("LamaAppVS.Shared.Models.Motocicleta", b =>
                {
                    b.Property<int>("ID_Motocicleta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Motocicleta"));

                    b.Property<int>("Cilindrada")
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

                    b.HasKey("ID_Motocicleta");

                    b.ToTable("Motocicletas");
                });

            modelBuilder.Entity("LamaAppVS.Shared.Models.Pareja", b =>
                {
                    b.Property<int>("ID_Pareja")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Pareja"));

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nombre")
                        .HasColumnType("int");

                    b.HasKey("ID_Pareja");

                    b.ToTable("Parejas");
                });

            modelBuilder.Entity("LamaAppVS.Shared.Models.Publicacion", b =>
                {
                    b.Property<int>("ID_Publicacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Publicacion"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("ID_Usuario")
                        .HasColumnType("int");

                    b.HasKey("ID_Publicacion");

                    b.HasIndex("ID_Usuario");

                    b.ToTable("Publicaciones");
                });

            modelBuilder.Entity("LamaAppVS.Shared.Models.Usuario", b =>
                {
                    b.Property<int>("ID_Usuario")
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha_Nacimiento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_Registro")
                        .HasColumnType("datetime2");

                    b.Property<int>("ID_Capitulo")
                        .HasColumnType("int");

                    b.Property<int>("ID_Contacto")
                        .HasColumnType("int");

                    b.Property<int>("ID_Motocicleta")
                        .HasColumnType("int");

                    b.Property<int>("ID_Pareja")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre_Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Usuario");

                    b.HasIndex("ID_Capitulo");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("LamaAppVS.Shared.Models.Evento", b =>
                {
                    b.HasOne("LamaAppVS.Shared.Models.Capitulo", "Capitulo")
                        .WithMany("Eventos")
                        .HasForeignKey("ID_Capitulo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Capitulo");
                });

            modelBuilder.Entity("LamaAppVS.Shared.Models.Inscripcion", b =>
                {
                    b.HasOne("LamaAppVS.Shared.Models.Evento", "Evento")
                        .WithMany("Inscripciones")
                        .HasForeignKey("ID_Evento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LamaAppVS.Shared.Models.Usuario", "Usuario")
                        .WithMany("Inscripciones")
                        .HasForeignKey("ID_Usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("LamaAppVS.Shared.Models.Publicacion", b =>
                {
                    b.HasOne("LamaAppVS.Shared.Models.Usuario", "Usuario")
                        .WithMany("Publicaciones")
                        .HasForeignKey("ID_Usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("LamaAppVS.Shared.Models.Usuario", b =>
                {
                    b.HasOne("LamaAppVS.Shared.Models.Capitulo", "Capitulo")
                        .WithMany("Usuarios")
                        .HasForeignKey("ID_Capitulo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LamaAppVS.Shared.Models.Contacto", "Contacto")
                        .WithOne("Usuario")
                        .HasForeignKey("LamaAppVS.Shared.Models.Usuario", "ID_Usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LamaAppVS.Shared.Models.Motocicleta", "Motocicleta")
                        .WithOne("Usuario")
                        .HasForeignKey("LamaAppVS.Shared.Models.Usuario", "ID_Usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LamaAppVS.Shared.Models.Pareja", "Pareja")
                        .WithOne("Usuario")
                        .HasForeignKey("LamaAppVS.Shared.Models.Usuario", "ID_Usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Capitulo");

                    b.Navigation("Contacto");

                    b.Navigation("Motocicleta");

                    b.Navigation("Pareja");
                });

            modelBuilder.Entity("LamaAppVS.Shared.Models.Capitulo", b =>
                {
                    b.Navigation("Eventos");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("LamaAppVS.Shared.Models.Contacto", b =>
                {
                    b.Navigation("Usuario")
                        .IsRequired();
                });

            modelBuilder.Entity("LamaAppVS.Shared.Models.Evento", b =>
                {
                    b.Navigation("Inscripciones");
                });

            modelBuilder.Entity("LamaAppVS.Shared.Models.Motocicleta", b =>
                {
                    b.Navigation("Usuario")
                        .IsRequired();
                });

            modelBuilder.Entity("LamaAppVS.Shared.Models.Pareja", b =>
                {
                    b.Navigation("Usuario")
                        .IsRequired();
                });

            modelBuilder.Entity("LamaAppVS.Shared.Models.Usuario", b =>
                {
                    b.Navigation("Inscripciones");

                    b.Navigation("Publicaciones");
                });
#pragma warning restore 612, 618
        }
    }
}
