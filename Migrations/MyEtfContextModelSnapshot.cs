﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyEtf.Context;

namespace etf.myemitent.ru.Migrations
{
    [DbContext(typeof(MyEtfContext))]
    partial class MyEtfContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("MyEtf.Models.Data.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("MyEtf.Models.Data.Etf", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CountryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Etfs");
                });

            modelBuilder.Entity("MyEtf.Models.Data.EtfCountryAllocation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<float>("Allocation")
                        .HasColumnType("REAL");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EtfId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EtfId");

                    b.ToTable("EtfCountryAllocations");
                });

            modelBuilder.Entity("MyEtf.Models.Data.Etf", b =>
                {
                    b.HasOne("MyEtf.Models.Data.Country", null)
                        .WithMany("Etfs")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("MyEtf.Models.Data.EtfCountryAllocation", b =>
                {
                    b.HasOne("MyEtf.Models.Data.Etf", null)
                        .WithMany("Allocations")
                        .HasForeignKey("EtfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyEtf.Models.Data.Country", b =>
                {
                    b.Navigation("Etfs");
                });

            modelBuilder.Entity("MyEtf.Models.Data.Etf", b =>
                {
                    b.Navigation("Allocations");
                });
#pragma warning restore 612, 618
        }
    }
}
