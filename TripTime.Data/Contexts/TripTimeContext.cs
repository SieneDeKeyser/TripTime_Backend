using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using TripTime.Domain.Files;
using TripTime.Domain.Trips;
using TripTime.Domain.Users;

namespace TripTime.Data.Contexts
{
    public partial class TripTimeContext : DbContext
    {
        private readonly ILoggerFactory _logger;

        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<TripSchedule> TripSchedules { get; set; }
        public DbSet<BookingTrip> BookingTrips { get; set; }

        public TripTimeContext(DbContextOptions<TripTimeContext> options) : base(options)
        {
        }
        public TripTimeContext(DbContextOptions<TripTimeContext> options, ILoggerFactory logger) : base(options)
        {
            _logger = logger;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var options = new DbContextOptionsBuilder<TripTimeContext>()
                .EnableSensitiveDataLogging()
                .UseLoggerFactory(_logger)
                .Options;

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasKey(user => user.Id);

            modelBuilder.Entity<User>()
                .OwnsOne(user => user.Email, email =>
                {
                    email.Property(prop => prop.Address).HasColumnName("Email");
                });

            modelBuilder.Entity<User>()
                .OwnsOne(user => user.SecurePassword, pass =>
                {
                    pass.Property(prop => prop.PasswordHash).HasColumnName("HashPassword");
                    pass.Property(prop => prop.Salt).HasColumnName("AppliedSalt");
                });

            modelBuilder.Entity<Client>()
                .HasOne(cl => cl.Address)
                .WithOne()
                .HasForeignKey<Client>(cl => cl.AddressId);
                

            modelBuilder.Entity<Admin>();

            modelBuilder.Entity<Hotel>()
                .ToTable("Hotels")
                .HasKey(hotel => hotel.Id);

            modelBuilder.Entity<Hotel>()
                .HasOne(cl => cl.Address)
                .WithOne()
                .HasForeignKey<Hotel>(cl => cl.AddressId);

            modelBuilder.Entity<Trip>()
                .ToTable("Trips")
                .HasKey(trip => trip.Id);

            modelBuilder.Entity<Trip>()
                .HasOne(trip => trip.Hotel)
                .WithMany()
                .HasForeignKey(trip => trip.HotelId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Image>()
                .ToTable("Images")
                .HasKey(image => image.Id);

            modelBuilder.Entity<Image>()
                .HasOne(image => image.Trip)
                .WithMany(trip => trip.Images)
                .HasForeignKey(image => image.TripId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Image>()
                .HasOne(image => image.User)
                .WithMany()
                .HasForeignKey(image => image.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TripSchedule>()
                .ToTable("TripSchedules")
                .HasKey(tripSchedule => tripSchedule.Id);

            modelBuilder.Entity<TripSchedule>()
                .HasOne(tripSchedule => tripSchedule.Trip)
                .WithMany()
                .HasForeignKey(tripSchedule => tripSchedule.TripId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookingTrip>()
                .ToTable("BookingTrips")
                .HasKey(bookingTrip => bookingTrip.Id);

            modelBuilder.Entity<BookingTrip>()
                .HasOne(bookingTrip => bookingTrip.TripSchedule)
                .WithMany()
                .HasForeignKey(bookingTrip => bookingTrip.TripScheduleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
