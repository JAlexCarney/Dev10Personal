﻿// <auto-generated />
using System;
using InvoiceSchemaMigration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InvoiceSchemaMigration.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InvoiceSchemaMigration.Entities.Carrier", b =>
                {
                    b.Property<int>("CarrierID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarrierName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarrierID");

                    b.ToTable("Carrier");
                });

            modelBuilder.Entity("InvoiceSchemaMigration.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("InvoiceSchemaMigration.Entities.Invoice", b =>
                {
                    b.Property<int>("InvoiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarrierID")
                        .HasColumnType("int");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("InvoiceID");

                    b.HasIndex("CarrierID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("InvoiceSchemaMigration.Entities.Invoice", b =>
                {
                    b.HasOne("InvoiceSchemaMigration.Entities.Carrier", "Carrier")
                        .WithMany("Invoices")
                        .HasForeignKey("CarrierID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InvoiceSchemaMigration.Entities.Customer", "Customer")
                        .WithMany("Invoice")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrier");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("InvoiceSchemaMigration.Entities.Carrier", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("InvoiceSchemaMigration.Entities.Customer", b =>
                {
                    b.Navigation("Invoice");
                });
#pragma warning restore 612, 618
        }
    }
}
