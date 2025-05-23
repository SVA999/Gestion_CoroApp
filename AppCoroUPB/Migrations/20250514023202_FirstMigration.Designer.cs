﻿// <auto-generated />
using System;
using AppCoroUPB.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppCoroUPB.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250514023202_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppCoroUPB.Models.Ensayo", b =>
                {
                    b.Property<int>("idEns")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Fecha")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("Hora")
                        .HasColumnType("time");

                    b.Property<int>("idLugEns")
                        .HasColumnType("int");

                    b.HasKey("idEns");

                    b.ToTable("Ensayos");
                });
#pragma warning restore 612, 618
        }
    }
}
