﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReolMarked.DataStorageLayer;

#nullable disable

namespace ReolMarked.Migrations
{
    [DbContext(typeof(SqliteDbContext))]
    [Migration("20230926112605_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("ReolMarked.DomainLayer.LeaseAgreement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("RentDuration")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RenterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ShelvesCount")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RenterId");

                    b.ToTable("LeaseAgreements");
                });

            modelBuilder.Entity("ReolMarked.DomainLayer.ShelfLeaseAgreement", b =>
                {
                    b.Property<int>("LeaseAgreementId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ShelfId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LeaseAgreementId", "ShelfId");

                    b.HasIndex("ShelfId");

                    b.ToTable("ShelfLeaseAgreement");
                });

            modelBuilder.Entity("ReolMarked.Renter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Renters");
                });

            modelBuilder.Entity("ReolMarked.Shelf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BookingEndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BookingStartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ShelfType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Shelves");
                });

            modelBuilder.Entity("ReolMarked.DomainLayer.LeaseAgreement", b =>
                {
                    b.HasOne("ReolMarked.Renter", "Renter")
                        .WithMany()
                        .HasForeignKey("RenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Renter");
                });

            modelBuilder.Entity("ReolMarked.DomainLayer.ShelfLeaseAgreement", b =>
                {
                    b.HasOne("ReolMarked.DomainLayer.LeaseAgreement", "LeaseAgreement")
                        .WithMany()
                        .HasForeignKey("LeaseAgreementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReolMarked.Shelf", "Shelf")
                        .WithMany()
                        .HasForeignKey("ShelfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LeaseAgreement");

                    b.Navigation("Shelf");
                });
#pragma warning restore 612, 618
        }
    }
}
