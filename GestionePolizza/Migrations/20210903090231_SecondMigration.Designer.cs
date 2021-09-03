﻿// <auto-generated />
using System;
using GestionePolizza.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GestionePolizza.Migrations
{
    [DbContext(typeof(PolicyContext))]
    [Migration("20210903090231_SecondMigration")]
    partial class SecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GestionePolizza.Core.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("varchar(16)");

                    b.Property<string>("FirstName")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "VRDMRA7891LH2D67",
                            FirstName = "Maria",
                            LastName = "Verdi"
                        },
                        new
                        {
                            Id = 2,
                            Code = "RSSLCA45H67LK097",
                            FirstName = "Luca",
                            LastName = "Rossi"
                        });
                });

            modelBuilder.Entity("GestionePolizza.Core.Models.InsurancePolicy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("MonthlyRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("PolicyType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Policies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 2,
                            ExpirationDate = new DateTime(2025, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MonthlyRate = 80m,
                            Number = 1872,
                            PolicyType = 1
                        });
                });

            modelBuilder.Entity("GestionePolizza.Core.Models.InsurancePolicy", b =>
                {
                    b.HasOne("GestionePolizza.Core.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });
#pragma warning restore 612, 618
        }
    }
}
