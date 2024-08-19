﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Postcrossing.Storage;

#nullable disable

namespace Postcrossing.Storage.Migrations
{
    [DbContext(typeof(PostcrossingDbContext))]
    [Migration("20240817210711_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Postcrossing.Storage.Models.Address.AddressEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<int>("CountyId")
                        .HasColumnType("integer");

                    b.Property<int>("DistrictId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountyId");

                    b.HasIndex("DistrictId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Postcrossing.Storage.Models.Address.CityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DistrictId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Postcrossing.Storage.Models.Address.CountyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Postcrossing.Storage.Models.Address.DistrictEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CountyId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("CountyId");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("Postcrossing.Storage.Models.Address.AddressEntity", b =>
                {
                    b.HasOne("Postcrossing.Storage.Models.Address.CityEntity", "City")
                        .WithMany("Addresses")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Postcrossing.Storage.Models.Address.CountyEntity", "Country")
                        .WithMany("Addresses")
                        .HasForeignKey("CountyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Postcrossing.Storage.Models.Address.DistrictEntity", "District")
                        .WithMany("Addresses")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Country");

                    b.Navigation("District");
                });

            modelBuilder.Entity("Postcrossing.Storage.Models.Address.CityEntity", b =>
                {
                    b.HasOne("Postcrossing.Storage.Models.Address.DistrictEntity", "Distric")
                        .WithMany("Cities")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Distric");
                });

            modelBuilder.Entity("Postcrossing.Storage.Models.Address.DistrictEntity", b =>
                {
                    b.HasOne("Postcrossing.Storage.Models.Address.CountyEntity", "County")
                        .WithMany("Districts")
                        .HasForeignKey("CountyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("County");
                });

            modelBuilder.Entity("Postcrossing.Storage.Models.Address.CityEntity", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("Postcrossing.Storage.Models.Address.CountyEntity", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Districts");
                });

            modelBuilder.Entity("Postcrossing.Storage.Models.Address.DistrictEntity", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
