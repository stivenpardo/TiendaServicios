﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TiendaServicio.Api.CarritoCompra.Persintence;

namespace TiendaServicio.Api.CarritoCompra.Migrations
{
    [DbContext(typeof(CartContext))]
    [Migration("20210125230922_MigrationSqlServerInitial")]
    partial class MigrationSqlServerInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TiendaServicio.Api.CarritoCompra.Model.SessionCart", b =>
                {
                    b.Property<int>("SesionCartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("SesionCartId");

                    b.ToTable("SessionCart");
                });

            modelBuilder.Entity("TiendaServicio.Api.CarritoCompra.Model.SessionCartDetail", b =>
                {
                    b.Property<int>("SesionCartDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SelectedProduct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SesionCartId")
                        .HasColumnType("int");

                    b.HasKey("SesionCartDetailId");

                    b.HasIndex("SesionCartId");

                    b.ToTable("SessionCartDetail");
                });

            modelBuilder.Entity("TiendaServicio.Api.CarritoCompra.Model.SessionCartDetail", b =>
                {
                    b.HasOne("TiendaServicio.Api.CarritoCompra.Model.SessionCart", "SesionCart")
                        .WithMany("DetailList")
                        .HasForeignKey("SesionCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
