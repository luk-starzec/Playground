using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using StrategyExample.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyExample
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
            // for InterfaceController
            services.AddScoped<ICustomLogger, FileLogger>();
            services.AddScoped<ICustomLogger, DbLogger>();
            services.AddScoped<ICustomLogger, EventLogger>();

            // for ResolverController
            services.AddScoped<Func<EnumLoggerType, ICustomLogger>>(sp => key =>
            {
                var s = sp.GetServices<ICustomLogger>();
                return s.Where(r => r.Logger == key).FirstOrDefault();
            });

            //// for ResolverController different version
            //services.AddScoped<FileLogger>();
            //services.AddScoped<DbLogger>();
            //services.AddScoped<EventLogger>();
            //services.AddScoped<Func<EnumLoggerType, ICustomLogger>>(sp => key =>
            //{
            //    switch (key)
            //    {
            //        case EnumLoggerType.File:
            //            return sp.GetRequiredService<FileLogger>();
            //        case EnumLoggerType.Db:
            //            return sp.GetRequiredService<DbLogger>();
            //        case EnumLoggerType.Event:
            //            return sp.GetRequiredService<EventLogger>();
            //        default:
            //            return sp.GetRequiredService<FileLogger>();
            //    }
            //});

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StrategyExample", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StrategyExample v1"));
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
