﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentalPage.Dal;

#nullable disable

namespace RentalPage.Dal.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220526141658_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RentalPage.Dal.Models.RentedItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("EndOfRenting")
                        .HasColumnType("datetime2");

                    b.Property<int>("RentItemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartOfRenting")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RentItemId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("RentedItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndOfRenting = new DateTime(2022, 9, 3, 0, 0, 0, 0, DateTimeKind.Local),
                            RentItemId = 2,
                            StartOfRenting = new DateTime(2022, 5, 26, 0, 0, 0, 0, DateTimeKind.Local),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            EndOfRenting = new DateTime(2022, 9, 3, 0, 0, 0, 0, DateTimeKind.Local),
                            RentItemId = 4,
                            StartOfRenting = new DateTime(2022, 5, 26, 0, 0, 0, 0, DateTimeKind.Local),
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            EndOfRenting = new DateTime(2022, 9, 3, 0, 0, 0, 0, DateTimeKind.Local),
                            RentItemId = 3,
                            StartOfRenting = new DateTime(2022, 5, 26, 0, 0, 0, 0, DateTimeKind.Local),
                            UserId = 2
                        },
                        new
                        {
                            Id = 4,
                            EndOfRenting = new DateTime(2022, 9, 3, 0, 0, 0, 0, DateTimeKind.Local),
                            RentItemId = 6,
                            StartOfRenting = new DateTime(2022, 5, 26, 0, 0, 0, 0, DateTimeKind.Local),
                            UserId = 3
                        });
                });

            modelBuilder.Entity("RentalPage.Dal.Models.RentItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RentItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Available = true,
                            Category = "CATEGORY_SKI",
                            Description = "sielni lehet vele",
                            Name = "síléc",
                            Price = 500
                        },
                        new
                        {
                            Id = 2,
                            Available = true,
                            Category = "CATEGORY_SNOWBOARD",
                            Description = "tartja a bokád",
                            Name = "snowboard csizma",
                            Price = 1000
                        },
                        new
                        {
                            Id = 3,
                            Available = true,
                            Category = "CATEGORY_SNOWBOARD",
                            Description = "gyors",
                            Name = "snowboard",
                            Price = 2000
                        },
                        new
                        {
                            Id = 4,
                            Available = true,
                            Category = "CATEGORY_PROTECTIVEEQUIPMENTS",
                            Description = "szép kesztyű",
                            Name = "kesztyű",
                            Price = 220
                        },
                        new
                        {
                            Id = 5,
                            Available = true,
                            Category = "CATEGORY_SKI",
                            Description = "hegyes",
                            Name = "sí bot",
                            Price = 200
                        },
                        new
                        {
                            Id = 6,
                            Available = true,
                            Category = "CATEGORY_CLOTHING",
                            Description = "piros, nem engedi át a vizet",
                            Name = "snowboard nadrág",
                            Price = 1400
                        },
                        new
                        {
                            Id = 7,
                            Available = true,
                            Category = "CATEGORY_PROTECTIVEEQUIPMENTS",
                            Description = "védi a térded, fekete",
                            Name = "térdvédő",
                            Price = 1050
                        },
                        new
                        {
                            Id = 8,
                            Available = true,
                            Category = "CATEGORY_CLOTHING",
                            Description = "síkabát",
                            Name = "kabát",
                            Price = 2500
                        });
                });

            modelBuilder.Entity("RentalPage.Dal.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sarah Parker"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Michael Corse"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Anna Smith"
                        });
                });

            modelBuilder.Entity("RentalPage.Dal.Models.RentedItem", b =>
                {
                    b.HasOne("RentalPage.Dal.Models.RentItem", "RentItem")
                        .WithOne("RentedItem")
                        .HasForeignKey("RentalPage.Dal.Models.RentedItem", "RentItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentalPage.Dal.Models.User", "User")
                        .WithMany("RentedItems")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RentItem");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RentalPage.Dal.Models.RentItem", b =>
                {
                    b.Navigation("RentedItem");
                });

            modelBuilder.Entity("RentalPage.Dal.Models.User", b =>
                {
                    b.Navigation("RentedItems");
                });
#pragma warning restore 612, 618
        }
    }
}
