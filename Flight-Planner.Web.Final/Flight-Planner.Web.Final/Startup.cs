using AutoMapper;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Data;
using Flight_Planner.Services;
using Flight_Planner.Services.Validators.AddFlightValidators;
using Flight_Planner.Services.Validators.SearchFlightsValidators;
using Flight_Planner.Web.Final.Authentication;
using Flight_Planner.Web.Final.Mappings;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Flight_Planner.Web.Final
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Flight_Planner.Web.Final", Version = "v1" });
            });

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddDbContext<FlightPlannerDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("flight-planner")));

            services.AddScoped<IDbService, DbService>();
            services.AddScoped<IFlightPlannerDbContext, FlightPlannerDbContext>();
            services.AddScoped<IEntityService<Flight>, EntityService<Flight>>();
            services.AddScoped<IEntityService<Airport>, EntityService<Airport>>();
            services.AddScoped<IDbServiceExtended, DbServiceExtended>();
            services.AddScoped<IFlightService, FlightService>();
            services.AddScoped<IAirportService, AirportService>();
            services.AddScoped<IAddFlightValidator, AirportCarrierValidator>();
            services.AddScoped<IAddFlightValidator, AirportCityValidator>();
            services.AddScoped<IAddFlightValidator, AirportCodesEqualityValidator>();
            services.AddScoped<IAddFlightValidator, AirportCodeValidator>();
            services.AddScoped<IAddFlightValidator, AirportCodeValidator>();
            services.AddScoped<IAddFlightValidator, ArrivalTimeValidator>();
            services.AddScoped<IAddFlightValidator, DepartureTimeValidator>();
            services.AddScoped<IAddFlightValidator, TimeFrameValidator>();
            services.AddScoped<ISearchFlightsValidator, AirportEqualsValidator>();
            services.AddScoped<ISearchFlightsValidator, AirportFromValidator>();
            services.AddScoped<ISearchFlightsValidator, AirportToValidator>();
            services.AddScoped<ISearchFlightsValidator, DepartureDateValidator>();
            services.AddScoped<ISearchFlightMapper, SearchFlightMapper>();

            var cfg = AutoMapperConfiguration.GetConfig();
            services.AddSingleton(typeof(IMapper), cfg); // mapper
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Flight_Planner.Web.Final v1"));
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
