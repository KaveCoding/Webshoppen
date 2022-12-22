﻿// <auto-generated />
using System;
using EF_Demo_many2many2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EF_Demo_many2many2.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20221222104320_changes")]
    partial class changes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EF_Demo_many2many2.Models.Beställning", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Antal")
                        .HasColumnType("int");

                    b.Property<int?>("BetalsättId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int?>("KundId")
                        .HasColumnType("int");

                    b.Property<int?>("ProduktId")
                        .HasColumnType("int");

                    b.Property<float>("Summa")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("BetalsättId");

                    b.HasIndex("KundId");

                    b.HasIndex("ProduktId");

                    b.ToTable("Beställningar");
                });

            modelBuilder.Entity("EF_Demo_many2many2.Models.Betalsätt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Namn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Betalsätter");
                });

            modelBuilder.Entity("EF_Demo_many2many2.Models.Kategori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Namn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kategorier");
                });

            modelBuilder.Entity("EF_Demo_many2many2.Models.Kund", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GatuNamn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Land")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Namn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonNummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonNummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kunder");
                });

            modelBuilder.Entity("EF_Demo_many2many2.Models.LagerStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ProduktId")
                        .HasColumnType("int");

                    b.Property<int>("Saldo")
                        .HasColumnType("int");

                    b.Property<bool>("Tillgänglig")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ProduktId");

                    b.ToTable("LagerStatusar");
                });

            modelBuilder.Entity("EF_Demo_many2many2.Models.Leverantör", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("LeveransTid")
                        .HasColumnType("int");

                    b.Property<string>("Namn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Pris")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Leverantörer");
                });

            modelBuilder.Entity("EF_Demo_many2many2.Models.Produkt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Info")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KategoriId")
                        .HasColumnType("int");

                    b.Property<int?>("LeverantörId")
                        .HasColumnType("int");

                    b.Property<string>("Namn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Pris")
                        .HasColumnType("real");

                    b.Property<string>("Storlek")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UtvaldProdukt")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("KategoriId");

                    b.HasIndex("LeverantörId");

                    b.ToTable("Produkter");
                });

            modelBuilder.Entity("EF_Demo_many2many2.Models.Beställning", b =>
                {
                    b.HasOne("EF_Demo_many2many2.Models.Betalsätt", null)
                        .WithMany("Beställningar")
                        .HasForeignKey("BetalsättId");

                    b.HasOne("EF_Demo_many2many2.Models.Kund", null)
                        .WithMany("Beställningar")
                        .HasForeignKey("KundId");

                    b.HasOne("EF_Demo_many2many2.Models.Produkt", null)
                        .WithMany("Beställningar")
                        .HasForeignKey("ProduktId");
                });

            modelBuilder.Entity("EF_Demo_many2many2.Models.LagerStatus", b =>
                {
                    b.HasOne("EF_Demo_many2many2.Models.Produkt", null)
                        .WithMany("Lagerstatusar")
                        .HasForeignKey("ProduktId");
                });

            modelBuilder.Entity("EF_Demo_many2many2.Models.Produkt", b =>
                {
                    b.HasOne("EF_Demo_many2many2.Models.Kategori", null)
                        .WithMany("Produkter")
                        .HasForeignKey("KategoriId");

                    b.HasOne("EF_Demo_many2many2.Models.Leverantör", null)
                        .WithMany("Produkter")
                        .HasForeignKey("LeverantörId");
                });

            modelBuilder.Entity("EF_Demo_many2many2.Models.Betalsätt", b =>
                {
                    b.Navigation("Beställningar");
                });

            modelBuilder.Entity("EF_Demo_many2many2.Models.Kategori", b =>
                {
                    b.Navigation("Produkter");
                });

            modelBuilder.Entity("EF_Demo_many2many2.Models.Kund", b =>
                {
                    b.Navigation("Beställningar");
                });

            modelBuilder.Entity("EF_Demo_many2many2.Models.Leverantör", b =>
                {
                    b.Navigation("Produkter");
                });

            modelBuilder.Entity("EF_Demo_many2many2.Models.Produkt", b =>
                {
                    b.Navigation("Beställningar");

                    b.Navigation("Lagerstatusar");
                });
#pragma warning restore 612, 618
        }
    }
}
