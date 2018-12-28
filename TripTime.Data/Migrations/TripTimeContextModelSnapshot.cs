﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TripTime.Data.Contexts;

namespace TripTime.Data.Migrations
{
    [DbContext(typeof(TripTimeContext))]
    partial class TripTimeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TripTime.Domain.ContactInformation.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("StreetName");

                    b.Property<string>("StreetNumber");

                    b.Property<int>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("TripTime.Domain.Files.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Extentsion");

                    b.Property<byte[]>("ImageInBytes");

                    b.Property<Guid>("TripId");

                    b.Property<DateTime>("UploadedDate");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.HasIndex("UserId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("TripTime.Domain.Trips.BookingTrip", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ClientId");

                    b.Property<decimal>("TotalPrice");

                    b.Property<Guid>("TripScheduleId");

                    b.HasKey("Id");

                    b.HasIndex("TripScheduleId");

                    b.ToTable("BookingTrips");
                });

            modelBuilder.Entity("TripTime.Domain.Trips.Hotel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AddressId");

                    b.Property<string>("ContactPerson");

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("TripTime.Domain.Trips.Trip", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("BasicPrice");

                    b.Property<int>("Capacity");

                    b.Property<Guid>("HotelId");

                    b.Property<string>("Schedule");

                    b.Property<int>("TransportType");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("TripTime.Domain.Trips.TripSchedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DeparturePlace");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("ReturnPlace");

                    b.Property<DateTime>("StartDate");

                    b.Property<Guid>("TripId");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("TripSchedules");
                });

            modelBuilder.Entity("TripTime.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("TripTime.Domain.Users.Admin", b =>
                {
                    b.HasBaseType("TripTime.Domain.Users.User");


                    b.ToTable("Admin");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("TripTime.Domain.Users.Client", b =>
                {
                    b.HasBaseType("TripTime.Domain.Users.User");

                    b.Property<Guid>("AddressId");

                    b.Property<string>("Rating");

                    b.Property<DateTime>("RegistrationDate");

                    b.HasIndex("AddressId");

                    b.ToTable("Client");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("TripTime.Domain.Files.Image", b =>
                {
                    b.HasOne("TripTime.Domain.Trips.Trip", "Trip")
                        .WithMany("Images")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TripTime.Domain.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TripTime.Domain.Trips.BookingTrip", b =>
                {
                    b.HasOne("TripTime.Domain.Trips.TripSchedule", "TripSchedule")
                        .WithMany()
                        .HasForeignKey("TripScheduleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TripTime.Domain.Trips.Hotel", b =>
                {
                    b.HasOne("TripTime.Domain.ContactInformation.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TripTime.Domain.Trips.Trip", b =>
                {
                    b.HasOne("TripTime.Domain.Trips.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TripTime.Domain.Trips.TripSchedule", b =>
                {
                    b.HasOne("TripTime.Domain.Trips.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TripTime.Domain.Users.User", b =>
                {
                    b.OwnsOne("System.Net.Mail.MailAddress", "Email", b1 =>
                        {
                            b1.Property<Guid?>("UserId");

                            b1.Property<string>("Address")
                                .HasColumnName("Email");

                            b1.ToTable("Users");

                            b1.HasOne("TripTime.Domain.Users.User")
                                .WithOne("Email")
                                .HasForeignKey("System.Net.Mail.MailAddress", "UserId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("TripTime.Domain.Users.UserSecurity", "SecurePassword", b1 =>
                        {
                            b1.Property<Guid?>("UserId");

                            b1.Property<string>("PasswordHash")
                                .HasColumnName("HashPassword");

                            b1.Property<string>("Salt")
                                .HasColumnName("AppliedSalt");

                            b1.ToTable("Users");

                            b1.HasOne("TripTime.Domain.Users.User")
                                .WithOne("SecurePassword")
                                .HasForeignKey("TripTime.Domain.Users.UserSecurity", "UserId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("TripTime.Domain.Users.Client", b =>
                {
                    b.HasOne("TripTime.Domain.ContactInformation.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
