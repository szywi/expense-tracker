using System.Text.Json.Serialization;
using ExpenseTracker.Infrastructure.Route;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;

namespace ExpenseTracker
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(options =>
            {
                options.ClearProviders();
                options.AddConsole();
#if DEBUG
                options.AddDebug();
#endif
            });

            services.AddCors();

            services.AddControllers(x => x.Conventions.Add(new ApiRoutePrefixConvention()))
                .AddJsonOptions(opt => { opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); })
                .AddFluentValidation(o =>
                {
                    o.LocalizationEnabled = false;
                    o.RegisterValidatorsFromAssemblyContaining<Startup>();
                })
                .AddControllersAsServices();

            services.ComposeApi();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                IdentityModelEventSource.ShowPII = true;
            }

            app.UseRouting();

            app.UseCors(b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}