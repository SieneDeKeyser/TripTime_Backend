using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TripTime.API;
using TripTime.Data.Contexts;

namespace TripTime_IntegrationTests
{
   public class TestStartup: Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {
        }

        protected override DbContextOptions<TripTimeContext> ConfigureDbContext()
        {
            return new DbContextOptionsBuilder<TripTimeContext>()
                .UseInMemoryDatabase("Triptime" + Guid.NewGuid().ToString("N")).Options;
        }

        protected override void ConfigureAdditionalServices(IServiceCollection services)
        {
            base.ConfigureAdditionalServices(services);

            //This is required for MVC to find our Controllers in our TestStartup
            services.AddMvc()
                .AddApplicationPart(typeof(Startup).Assembly);
        }

    }
}
