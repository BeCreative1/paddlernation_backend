﻿// <auto-generated />
using System;
using EfcDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EfcDataAccess.Migrations
{
    [DbContext(typeof(PaddlerNationContext))]
    partial class PaddlerNationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("Domain.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Zip")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Domain.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Domain.Delivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AtID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DeliveryType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("TotalKilometers")
                        .HasColumnType("REAL");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("AtID");

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("Domain.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Activity")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("CVR")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("HeldAtID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("TimeSpan")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("HeldAtID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Domain.Extra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MaxAmount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Extras");
                });

            modelBuilder.Entity("Domain.ExtrasOrder", b =>
                {
                    b.Property<int>("ExtrasID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.HasKey("ExtrasID", "OrderID");

                    b.HasIndex("OrderID");

                    b.ToTable("ExtrasOrders");
                });

            modelBuilder.Entity("Domain.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DeliveryID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrderedByID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PaymentStage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryID");

                    b.HasIndex("OrderedByID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Domain.PaddleBoard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MinCapacity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PaddleBoardTypeID")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("PaddleBoardTypeID");

                    b.ToTable("PaddleBoards");
                });

            modelBuilder.Entity("Domain.PaddleBoardReservation", b =>
                {
                    b.Property<int>("ReservationID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PadleBoardID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ReservationID", "PadleBoardID");

                    b.HasIndex("PadleBoardID");

                    b.ToTable("PaddleBoardReservations");
                });

            modelBuilder.Entity("Domain.PaddleBoardType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NameOfType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PaddleBoardTypes");
                });

            modelBuilder.Entity("Domain.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderedInId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderedInId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Domain.Delivery", b =>
                {
                    b.HasOne("Domain.Address", "At")
                        .WithMany("Deliveries")
                        .HasForeignKey("AtID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("At");
                });

            modelBuilder.Entity("Domain.Event", b =>
                {
                    b.HasOne("Domain.Address", "HeldAt")
                        .WithMany("Events")
                        .HasForeignKey("HeldAtID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HeldAt");
                });

            modelBuilder.Entity("Domain.ExtrasOrder", b =>
                {
                    b.HasOne("Domain.Extra", "Extra")
                        .WithMany("ExtrasOrders")
                        .HasForeignKey("ExtrasID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Order", "Order")
                        .WithMany("ExtrasOrders")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Extra");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Domain.Order", b =>
                {
                    b.HasOne("Domain.Delivery", "Delivery")
                        .WithMany("Orders")
                        .HasForeignKey("DeliveryID");

                    b.HasOne("Domain.Customer", "OrderedBy")
                        .WithMany("Orders")
                        .HasForeignKey("OrderedByID");

                    b.Navigation("Delivery");

                    b.Navigation("OrderedBy");
                });

            modelBuilder.Entity("Domain.PaddleBoard", b =>
                {
                    b.HasOne("Domain.PaddleBoardType", "PaddleBoardType")
                        .WithMany("PaddleBoards")
                        .HasForeignKey("PaddleBoardTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaddleBoardType");
                });

            modelBuilder.Entity("Domain.PaddleBoardReservation", b =>
                {
                    b.HasOne("Domain.PaddleBoard", "PaddleBoard")
                        .WithMany("PaddleBoardReservations")
                        .HasForeignKey("PadleBoardID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Reservation", "Reservation")
                        .WithMany("PaddleBoardReservations")
                        .HasForeignKey("ReservationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaddleBoard");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("Domain.Reservation", b =>
                {
                    b.HasOne("Domain.Order", "OrderedIn")
                        .WithMany("Reservations")
                        .HasForeignKey("OrderedInId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderedIn");
                });

            modelBuilder.Entity("Domain.Address", b =>
                {
                    b.Navigation("Deliveries");

                    b.Navigation("Events");
                });

            modelBuilder.Entity("Domain.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Domain.Delivery", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Domain.Extra", b =>
                {
                    b.Navigation("ExtrasOrders");
                });

            modelBuilder.Entity("Domain.Order", b =>
                {
                    b.Navigation("ExtrasOrders");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Domain.PaddleBoard", b =>
                {
                    b.Navigation("PaddleBoardReservations");
                });

            modelBuilder.Entity("Domain.PaddleBoardType", b =>
                {
                    b.Navigation("PaddleBoards");
                });

            modelBuilder.Entity("Domain.Reservation", b =>
                {
                    b.Navigation("PaddleBoardReservations");
                });
#pragma warning restore 612, 618
        }
    }
}
