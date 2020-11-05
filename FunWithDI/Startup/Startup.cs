using FunWithDI.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace FunWithDI
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

            services
                .AddSingleton<IChild, Child>()
                .AddSingleton<ITopLevel, TopLevel>()
                .AddSingleton<IMidLevel, MidLevel>()
                .AddSingleton<IBottomLevel, BottomLevel>()
                .AddSingleton<ILevel, MidLevel>()
                .AddSingleton<ILevel, BottomLevel>()
                .AddScoped<ILevel, TopLevel>();

            /*
            var scenario = Configuration.GetSection("InjectionOptions").GetValue<Scenarios>("Scenario");
            _ = scenario switch
            {
                Scenarios.AllSingleton => services
                    .AddSingleton<IChild, Child>()
                    .AddSingleton<ITopLevel, TopLevel>()
                    .AddSingleton<IMidLevel, MidLevel>()
                    .AddSingleton<IBottomLevel, BottomLevel>(),

                Scenarios.TransientChild => services
                    .AddTransient<IChild, Child>()
                    .AddSingleton<ITopLevel, TopLevel>()
                    .AddSingleton<IMidLevel, MidLevel>()
                    .AddSingleton<IBottomLevel, BottomLevel>(),

                Scenarios.ScopedChild => services
                    .AddScoped<IChild, Child>()
                    .AddSingleton<ITopLevel, TopLevel>()
                    .AddSingleton<IMidLevel, MidLevel>()
                    .AddSingleton<IBottomLevel, BottomLevel>(),

                Scenarios.AllScoped => services
                    .AddScoped<IChild, Child>()
                    .AddScoped<ITopLevel, TopLevel>()
                    .AddScoped<IMidLevel, MidLevel>()
                    .AddScoped<IBottomLevel, BottomLevel>(),

                _ => throw new ArgumentOutOfRangeException(nameof(scenario))
            };
            //*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
