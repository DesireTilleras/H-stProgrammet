﻿// <auto-generated />
using System;
using Hastprogrammet.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hastprogrammet.Migrations
{
    [DbContext(typeof(HorseContext))]
    [Migration("20210816163831_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hastprogrammet.Model.Economy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int?>("HorseId")
                        .HasColumnType("int")
                        .HasColumnName("HorseId");

                    b.HasKey("Id");

                    b.HasIndex("HorseId");

                    b.ToTable("Economy");
                });

            modelBuilder.Entity("Hastprogrammet.Model.Horse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BirthYear")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Height")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Horse");
                });

            modelBuilder.Entity("Hastprogrammet.Model.Economy", b =>
                {
                    b.HasOne("Hastprogrammet.Model.Horse", "Horse")
                        .WithMany("Economies")
                        .HasForeignKey("HorseId")
                        .HasConstraintName("FK__Book__AuthorID__29572725");

                    b.Navigation("Horse");
                });

            modelBuilder.Entity("Hastprogrammet.Model.Horse", b =>
                {
                    b.Navigation("Economies");
                });
#pragma warning restore 612, 618
        }
    }
}