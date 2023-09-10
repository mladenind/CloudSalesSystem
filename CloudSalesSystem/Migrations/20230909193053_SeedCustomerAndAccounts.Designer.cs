﻿// <auto-generated />
using System;
using CloudSalesSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CloudSalesSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230909193053_SeedCustomerAndAccounts")]
    partial class SeedCustomerAndAccounts
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CloudSalesSystem.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 9, 9, 19, 30, 53, 189, DateTimeKind.Utc).AddTicks(9569),
                            CustomerId = 1,
                            Name = "First Test Account"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 9, 9, 19, 30, 53, 189, DateTimeKind.Utc).AddTicks(9570),
                            CustomerId = 1,
                            Name = "Second Test Account"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2023, 9, 9, 19, 30, 53, 189, DateTimeKind.Utc).AddTicks(9571),
                            CustomerId = 1,
                            Name = "Second Test Account"
                        });
                });

            modelBuilder.Entity("CloudSalesSystem.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 9, 9, 19, 30, 53, 189, DateTimeKind.Utc).AddTicks(9486),
                            Email = "supercustomer@crayon.com",
                            Name = "Super Customer"
                        });
                });

            modelBuilder.Entity("CloudSalesSystem.Models.Account", b =>
                {
                    b.HasOne("CloudSalesSystem.Models.Customer", "Customer")
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