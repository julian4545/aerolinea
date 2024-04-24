﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using aerolinea.dbcontext;

#nullable disable

namespace aerolinea.Migrations
{
    [DbContext(typeof(AgriversoDbcontext))]
    [Migration("20240423104825_prueba")]
    partial class prueba
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("aerolinea.Model.Asiento", b =>
                {
                    b.Property<int>("AsientoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AsientoId"));

                    b.Property<int>("AvionId")
                        .HasColumnType("int");

                    b.Property<string>("NumeroAsiento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AsientoId");

                    b.HasIndex("AvionId");

                    b.ToTable("Asiento");
                });

            modelBuilder.Entity("aerolinea.Model.Avion", b =>
                {
                    b.Property<int>("AvionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AvionId"));

                    b.Property<int>("CapacidadMaximaPasajeros")
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AvionId");

                    b.ToTable("Avion");
                });

            modelBuilder.Entity("aerolinea.Model.Pasajero", b =>
                {
                    b.Property<int>("PasajeroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PasajeroId"));

                    b.Property<string>("Cedula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cuidad")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PasajeroId");

                    b.ToTable("Pasajero");
                });

            modelBuilder.Entity("aerolinea.Model.Reserva", b =>
                {
                    b.Property<int>("ReservaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservaId"));

                    b.Property<int>("AsientoId")
                        .HasColumnType("int");

                    b.Property<int>("PasajeroId")
                        .HasColumnType("int");

                    b.Property<int>("VueloId")
                        .HasColumnType("int");

                    b.HasKey("ReservaId");

                    b.HasIndex("AsientoId");

                    b.HasIndex("PasajeroId");

                    b.HasIndex("VueloId");

                    b.ToTable("Reserva");
                });

            modelBuilder.Entity("aerolinea.Model.Tripulacion", b =>
                {
                    b.Property<int>("TripulacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TripulacionId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VueloId")
                        .HasColumnType("int");

                    b.HasKey("TripulacionId");

                    b.HasIndex("VueloId");

                    b.ToTable("Tripulacion");
                });

            modelBuilder.Entity("aerolinea.Model.Vuelo", b =>
                {
                    b.Property<int>("VueloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VueloId"));

                    b.Property<string>("AeropuertoLlegada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AeropuertoSalida")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstadoPuntualidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaLlegada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumeroVuelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VueloId");

                    b.ToTable("Vuelo");
                });

            modelBuilder.Entity("aerolinea.Model.Asiento", b =>
                {
                    b.HasOne("aerolinea.Model.Avion", "Avion")
                        .WithMany("Asientos")
                        .HasForeignKey("AvionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Avion");
                });

            modelBuilder.Entity("aerolinea.Model.Reserva", b =>
                {
                    b.HasOne("aerolinea.Model.Asiento", "Asiento")
                        .WithMany("Reservas")
                        .HasForeignKey("AsientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("aerolinea.Model.Pasajero", "Pasajero")
                        .WithMany("Reservas")
                        .HasForeignKey("PasajeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("aerolinea.Model.Vuelo", "Vuelo")
                        .WithMany("Reservas")
                        .HasForeignKey("VueloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asiento");

                    b.Navigation("Pasajero");

                    b.Navigation("Vuelo");
                });

            modelBuilder.Entity("aerolinea.Model.Tripulacion", b =>
                {
                    b.HasOne("aerolinea.Model.Vuelo", "Vuelo")
                        .WithMany("Tripulacion")
                        .HasForeignKey("VueloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vuelo");
                });

            modelBuilder.Entity("aerolinea.Model.Asiento", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("aerolinea.Model.Avion", b =>
                {
                    b.Navigation("Asientos");
                });

            modelBuilder.Entity("aerolinea.Model.Pasajero", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("aerolinea.Model.Vuelo", b =>
                {
                    b.Navigation("Reservas");

                    b.Navigation("Tripulacion");
                });
#pragma warning restore 612, 618
        }
    }
}
