using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace TripTime.Data.Contexts
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TripTimeContext>
    {
        private string _connectionstring = ".\\SQLExpress";


        public readonly ILoggerFactory efLoggerFactory
            = new LoggerFactory(new[] { new ConsoleLoggerProvider((category, level) => category.Contains("Command") && level == LogLevel.Information, true), });


        public DesignTimeDbContextFactory()
        {
        }

        public DesignTimeDbContextFactory(ILoggerFactory efLoggerFactory)
        {
            this.efLoggerFactory = efLoggerFactory;
        }


        public TripTimeContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<TripTimeContext>()
                .UseSqlServer($"Data Source={_connectionstring};Initial Catalog=TripTime;Integrated Security=True;")
                .EnableSensitiveDataLogging()
                .UseLoggerFactory(efLoggerFactory)
                .Options;

            return new TripTimeContext(options, efLoggerFactory);
        }
    }
}
