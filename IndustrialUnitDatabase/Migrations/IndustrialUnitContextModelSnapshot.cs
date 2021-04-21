﻿// <auto-generated />
using IndustrialUnitDatabase.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IndustrialUnitDatabase.Migrations
{
    [DbContext(typeof(IndustrialUnitContext))]
    partial class IndustrialUnitContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.14");

            modelBuilder.Entity("IndustrialUnitDatabase.Model.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Capacity")
                        .HasColumnType("TEXT");

                    b.Property<string>("ItemType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("PowerConsumption")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Pressure")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("IndustrialUnitDatabase.Model.Instrument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("InstallationType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ItemType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("TEXT");

                    b.Property<string>("MediumToMeasure")
                        .HasColumnType("TEXT");

                    b.Property<string>("OperationPrinciple")
                        .HasColumnType("TEXT");

                    b.Property<string>("Supplier")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Instrument");
                });

            modelBuilder.Entity("IndustrialUnitDatabase.Model.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ItemName")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("OrderId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("IndustrialUnitDatabase.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AdminName")
                        .HasColumnType("TEXT");

                    b.Property<string>("AdminPassword")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserPassword")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("IndustrialUnitDatabase.Model.Valve", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConnectionType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ItemType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("TEXT");

                    b.Property<string>("Operation")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Size")
                        .HasColumnType("TEXT");

                    b.Property<string>("Supplier")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Valve");
                });
#pragma warning restore 612, 618
        }
    }
}
