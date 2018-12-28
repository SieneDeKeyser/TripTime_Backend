using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TripTime.Domain.Users;

namespace TripTime.Data.Contexts
{
    public partial class TripTimeContext : DbContext
    {
        private readonly ILoggerFactory _logger;

        public virtual DbSet<User> Users { get; set; }

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
        { }
    }
}
