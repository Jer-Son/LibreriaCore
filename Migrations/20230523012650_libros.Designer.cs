﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestDb.Data;

#nullable disable

namespace TestDb.Migrations
{
    [DbContext(typeof(TestDbContext))]
    [Migration("20230523012650_libros")]
    partial class libros
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestDb.Models.Editorial", b =>
                {
                    b.Property<int>("IdEditorial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEditorial"));

                    b.Property<string>("NombreEditorial")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEditorial");

                    b.ToTable("Editorial");
                });

            modelBuilder.Entity("TestDb.Models.Libro", b =>
                {
                    b.Property<int>("IdLibro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLibro"));

                    b.Property<int>("AutorId")
                        .HasColumnType("int");

                    b.Property<int>("EditorialId")
                        .HasColumnType("int");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdLibro");

                    b.HasIndex("AutorId");

                    b.HasIndex("EditorialId");

                    b.ToTable("Libro");
                });

            modelBuilder.Entity("TestDb.Models.Persona", b =>
                {
                    b.Property<int>("IdPersona")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPersona"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPersona");

                    b.ToTable("Persona");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TestDb.Models.Prestamo", b =>
                {
                    b.Property<int>("IdPrestamo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrestamo"));

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("fechaFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fechaInicio")
                        .HasColumnType("datetime2");

                    b.HasKey("IdPrestamo");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Prestamo");
                });

            modelBuilder.Entity("TestDb.Models.PrestamoInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("LibroId")
                        .HasColumnType("int");

                    b.Property<int?>("PrestamoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LibroId");

                    b.HasIndex("PrestamoId");

                    b.ToTable("PrestamoInfo");
                });

            modelBuilder.Entity("TestDb.Models.Autor", b =>
                {
                    b.HasBaseType("TestDb.Models.Persona");

                    b.HasDiscriminator().HasValue("Autor");
                });

            modelBuilder.Entity("TestDb.Models.Usuario", b =>
                {
                    b.HasBaseType("TestDb.Models.Persona");

                    b.Property<int?>("Telefono")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Usuario");
                });

            modelBuilder.Entity("TestDb.Models.Libro", b =>
                {
                    b.HasOne("TestDb.Models.Autor", "Autor")
                        .WithMany("libros")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestDb.Models.Editorial", "Editorial")
                        .WithMany("libros")
                        .HasForeignKey("EditorialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Editorial");
                });

            modelBuilder.Entity("TestDb.Models.Prestamo", b =>
                {
                    b.HasOne("TestDb.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TestDb.Models.PrestamoInfo", b =>
                {
                    b.HasOne("TestDb.Models.Libro", "Libro")
                        .WithMany("PrestamoList")
                        .HasForeignKey("LibroId");

                    b.HasOne("TestDb.Models.Prestamo", "Prestamo")
                        .WithMany("PrestamoInfo")
                        .HasForeignKey("PrestamoId");

                    b.Navigation("Libro");

                    b.Navigation("Prestamo");
                });

            modelBuilder.Entity("TestDb.Models.Editorial", b =>
                {
                    b.Navigation("libros");
                });

            modelBuilder.Entity("TestDb.Models.Libro", b =>
                {
                    b.Navigation("PrestamoList");
                });

            modelBuilder.Entity("TestDb.Models.Prestamo", b =>
                {
                    b.Navigation("PrestamoInfo");
                });

            modelBuilder.Entity("TestDb.Models.Autor", b =>
                {
                    b.Navigation("libros");
                });
#pragma warning restore 612, 618
        }
    }
}
