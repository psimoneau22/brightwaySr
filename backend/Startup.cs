using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace backend
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration) {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllersWithViews()
                .AddJsonOptions(options => {
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                });

            services.Configure<TravelSettings>(Configuration.GetSection(TravelSettings.AppSettingName));

            services.AddDbContextFactory<TravelDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString(Databases.TravelDB.AppSettingName)));
            services.AddDbContext<TravelDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString(Databases.TravelDB.AppSettingName)));


            services.AddHttpClient<ExchangeProxy>(client => {
                var apiConfig = Configuration.GetSection(ExchangeProxy.AppSettingName);
                client.BaseAddress = new System.Uri(apiConfig.GetValue<string>("BaseAddress"));
                client.DefaultRequestHeaders.Add("X-RapidAPI-Key", apiConfig.GetValue<string>("ApplicationKey"));
                client.DefaultRequestHeaders.Add("X-RapidAPI-Host", apiConfig.GetValue<string>("currency-exchange.p.rapidapi.com"));
            });

            services.AddSingleton<DbProvider<TravelDbContext>>();
            services.AddTransient<CountryRepository>();
            services.AddTransient<BookingRepository>();
            services.AddTransient<BookingService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            // anything at /api will use API controllers
            app.Map("/api", true, app => {
                app.UseRouting();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            });

            // everything else will be served the spa
            app.UseRouting();
            app.UseEndpoints(endpoints => {
                endpoints.MapFallbackToController("Index", "Home");
            });
        }
    }
}
