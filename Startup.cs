using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using ProyectoIA.Repository.Repositorio;
using ProyectoIA.Repository;
using Microsoft.EntityFrameworkCore;
using ProyectoIA.Service;
using ProyectoIA.Repository.Repositorio.Order;
using ProyectoIA.Service.Order;

namespace ProyectoIA
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
            //services.AddControllersWithViews();

            services.AddEntityFrameworkSqlServer();

            var sqlConnectionString = Configuration.GetConnectionString("ConnActividadesDB");

            services.AddDbContextPool<IADBContext>(options => options.UseSqlServer(sqlConnectionString, providerOptions => providerOptions.EnableRetryOnFailure()));

            services.AddScoped<IRepositorioProductcs, RepositorioProduct>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IRepositorioOrders, RepositorioOrders>();
            services.AddScoped<IOrdersService, OrdersService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjectIA", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ActividadCRUD v1"));
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
