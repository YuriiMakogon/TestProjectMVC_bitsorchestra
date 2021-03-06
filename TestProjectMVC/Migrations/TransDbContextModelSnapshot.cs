﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestProjectMVC.Models;

namespace TestProjectMVC.Migrations
{
    [DbContext(typeof(TransDbContext))]
    partial class TransDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("TestProjectMVC.Models.TransModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Date1")
                        .HasColumnType("Date");

                    b.Property<bool>("Married")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal");

                    b.HasKey("id");

                    b.ToTable("Trans");
                });
#pragma warning restore 612, 618
        }
    }
}
