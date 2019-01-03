using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NLog;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TripTime.API.ContactInformation.DTO;
using TripTime.API.ContactInformation.Mapper;
using TripTime.API.Trips.DTO.Hotels;
using TripTime.API.Trips.Mapper;
using TripTime.API.Users.DTO.AdminDTO;
using TripTime.API.Users.DTO.ClientDTO;
using TripTime.API.Users.Mapper;
using TripTime.Data.Contexts;
using TripTime.Data.Repositories;
using TripTime.Domain.ContactInformation;
using TripTime.Domain.Trips;
using TripTime.Domain.Users;
using TripTime.Infrastructure.Exceptions;
using TripTime.Infrastructure.GlobalInterfaces;
using TripTime.Service.ContactInformations;
using TripTime.Service.Trips.Hotels;
using TripTime.Service.Users;
using TripTime.Service.Users.Security;

namespace TripTime.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureAdditionalServices(services);
        }

        protected virtual void ConfigureAdditionalServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "TripTime",
                    Version = "v1"
                });
            });

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IAddressService, AddressService>();

            services.AddScoped<IMapper<Admin, AdminDTO_Create, AdminDTO_Return>, AdminMapper>();
            services.AddScoped<IMapper<Client, ClientDTO_Create, ClientDTO_Return>, ClientMapper>();
            services.AddScoped<UserMapper>();
            services.AddScoped<IMapper<Address, AddressDTO_Create, AddressDTO_Return>, AddressMapper>();
            services.AddScoped<IMapper<Hotel, HotelDTO_Create, HotelDTO_Return>, HotelMapper>();

            services.AddScoped<UserRepository>();
            services.AddScoped<IRepository<Hotel>, HotelRepository>();
            services.AddScoped<IRepository<Address>, AddressRepository>();

            services.AddSingleton(ConfigureDbContext());
            services.AddTransient<TripTimeContext>();

            services.AddScoped<Hasher>();
            services.AddScoped<Salter>();
            services.AddScoped<UserAuthenticationService>();
            services
                .AddAuthorization(options =>
                {
                    options.AddPolicy("AdminOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
                })
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(UserAuthenticationService.GetSecretKey(Configuration["SecretKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }

        protected virtual DbContextOptions<TripTimeContext> ConfigureDbContext()
        {
            return new DbContextOptionsBuilder<TripTimeContext>()
                .UseSqlServer(GetConnectionString())
                .Options;
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TripTime App V1");
                c.RoutePrefix = string.Empty;
            });
           
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseAuthentication();

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvc();
        }

        private string GetConnectionString()
        {
            var connectionString = Environment.GetEnvironmentVariable("APPSETTING_SqlConnectionString", EnvironmentVariableTarget.Process);
            if (string.IsNullOrEmpty(connectionString))
            {
                System.Diagnostics.Trace.TraceWarning("The sql connection string environment variable was not found. Using the default.");
                connectionString = "Data Source=.\\SQLExpress;Initial Catalog=TripTime;Integrated Security=True;";
            }
            return connectionString;
        }
    }

}
