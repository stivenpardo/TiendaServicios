﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TiendaServicios.Api.Autor.Persistence;

namespace TiendaServicios.Api.Autor.Migrations
{
    [DbContext(typeof(AuthorContext))]
    [Migration("20210122143555_postgresMigrationInicial")]
    partial class postgresMigrationInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TiendaServicios.Api.Autor.Model.AcademicLevel", b =>
                {
                    b.Property<int>("AcademicLevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AcademyCenter")
                        .HasColumnType("integer");

                    b.Property<string>("AcedemiLevelGuid")
                        .HasColumnType("text");

                    b.Property<int>("BookAuthorId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("GradeDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("AcademicLevelId");

                    b.HasIndex("BookAuthorId");

                    b.ToTable("AcademyLevel");
                });

            modelBuilder.Entity("TiendaServicios.Api.Autor.Model.BookAuthor", b =>
                {
                    b.Property<int>("BookAuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("BookAuthorGuid")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("BookAuthorId");

                    b.ToTable("BookAuth");
                });

            modelBuilder.Entity("TiendaServicios.Api.Autor.Model.AcademicLevel", b =>
                {
                    b.HasOne("TiendaServicios.Api.Autor.Model.BookAuthor", "BookAuthor")
                        .WithMany("AcademyLevelList")
                        .HasForeignKey("BookAuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}