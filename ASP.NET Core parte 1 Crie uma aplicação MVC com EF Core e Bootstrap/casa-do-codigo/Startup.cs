﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using casa_do_codigo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace casa_do_codigo
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            // Auxiliar para manter as sessoses em cache
            services.AddDistributedMemoryCache();

            // Adiciona a Seção
            //services.AddSession(options => {
            //    options.CookieHttpOnly = true;
            //});
            services.AddSession();

            //string  connectionString = @"Data Source=VNTWKSW7575\SQLEXPRESS;" + "Initial Catalog=CasaDoCodigo;" + "User id=VENTURUS\vntleju;" + "Password=;" + "Integrated Security=true";
            string connectionString = Configuration.GetSection("ConnectionStrings").GetValue<string>("Default");
            services.AddDbContext<Context>(options => options.UseSqlServer(connectionString));
            
            // injeção de dependencias
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IDataService, DataService>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            // Indica que a aplicação vai usar uma seção
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Request}/{action=Carousel}/{id?}");
            });

            IDataService dataService = serviceProvider.GetService<IDataService>();
            dataService.InitDB();
        }
    }
}
