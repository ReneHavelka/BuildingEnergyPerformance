﻿// <auto-generated />
using System;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Models.BuildingElementComponents", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BuildingElementId")
                        .HasColumnType("int");

                    b.Property<int>("BuildingElementsId")
                        .HasColumnType("int");

                    b.Property<float?>("Dimension1")
                        .HasColumnType("real");

                    b.Property<float?>("Dimension2")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Resistance")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("BuildingElementsId");

                    b.ToTable("BuildingsElementComponents");
                });

            modelBuilder.Entity("Domain.Models.BuildingElements", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ContiguousSpace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Dimension1")
                        .HasColumnType("real");

                    b.Property<float>("Dimension2")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpacesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpacesId");

                    b.ToTable("BuildingElements");
                });

            modelBuilder.Entity("Domain.Models.Layers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Thickness")
                        .HasColumnType("real");

                    b.Property<int>("WallComponentsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WallComponentsId");

                    b.ToTable("Layers");
                });

            modelBuilder.Entity("Domain.Models.Spaces", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StoreysId")
                        .HasColumnType("int");

                    b.Property<float>("Temperature")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("StoreysId");

                    b.ToTable("Spaces");
                });

            modelBuilder.Entity("Domain.Models.SpaceTemperatures", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Temperature")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("SpaceTemperatures");
                });

            modelBuilder.Entity("Domain.Models.Storeys", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Storeys");
                });

            modelBuilder.Entity("Domain.Models.ThermalConductivityTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("ThermalConductivityTables");
                });

            modelBuilder.Entity("Domain.Models.ThermalResistanceTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("ThermalResistanceTable");
                });

            modelBuilder.Entity("Domain.Models.BuildingElementComponents", b =>
                {
                    b.HasOne("Domain.Models.BuildingElements", "BuildingElements")
                        .WithMany("BuildingElementComponents")
                        .HasForeignKey("BuildingElementsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BuildingElements");
                });

            modelBuilder.Entity("Domain.Models.BuildingElements", b =>
                {
                    b.HasOne("Domain.Models.Spaces", "Spaces")
                        .WithMany("BuildingElements")
                        .HasForeignKey("SpacesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Spaces");
                });

            modelBuilder.Entity("Domain.Models.Layers", b =>
                {
                    b.HasOne("Domain.Models.BuildingElementComponents", "WallComponents")
                        .WithMany("Layers")
                        .HasForeignKey("WallComponentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WallComponents");
                });

            modelBuilder.Entity("Domain.Models.Spaces", b =>
                {
                    b.HasOne("Domain.Models.Storeys", "Storeys")
                        .WithMany("Spaces")
                        .HasForeignKey("StoreysId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Storeys");
                });

            modelBuilder.Entity("Domain.Models.BuildingElementComponents", b =>
                {
                    b.Navigation("Layers");
                });

            modelBuilder.Entity("Domain.Models.BuildingElements", b =>
                {
                    b.Navigation("BuildingElementComponents");
                });

            modelBuilder.Entity("Domain.Models.Spaces", b =>
                {
                    b.Navigation("BuildingElements");
                });

            modelBuilder.Entity("Domain.Models.Storeys", b =>
                {
                    b.Navigation("Spaces");
                });
#pragma warning restore 612, 618
        }
    }
}
