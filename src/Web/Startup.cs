using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Services;
using Javeriana.Pica.ApplicationCore.Entities;
using Javeriana.Pica.ApplicationCore.Interfaces;
using Javeriana.Pica.ApplicationCore.Services;
using Javeriana.Pica.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Javeriana.Pica.Web
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

            //TODO en ésta sección se registran los repositorios
            services.AddSingleton<IRepository<CatalogItem>, CatalogRepository>();
            services.AddSingleton<IRepository<Order>, OrderRepository>();
            services.AddSingleton<IRepository<Basket>, BasketRepository>();
            //TODO en ésta sección se registran los servicios
            services.AddSingleton<ICatalogService, CatalogService>();
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<IBasketService, BasketService>();
            services.AddSingleton<IAppLogger<BasketService>, DummyService>();
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
