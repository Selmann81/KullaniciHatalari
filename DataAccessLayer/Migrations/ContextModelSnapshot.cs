﻿// <auto-generated />
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EntityLayer.Concrete.Hatalar", b =>
                {
                    b.Property<int>("HataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("HataBaslik")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("HataBitti")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("HataCozum")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Hataİcerik")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("HataId");

                    b.ToTable("Hata");
                });
#pragma warning restore 612, 618
        }
    }
}