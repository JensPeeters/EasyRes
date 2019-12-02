using Business_layer.Facades;
using Business_layer.Interfaces;
using Data_layer.Interfaces;
using Data_layer.Model;
using Data_layer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace easyres_api
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
            services.AddDbContext<DatabaseContext>(
                // options => options.UseMySQL(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")
                )
            );
            services.AddTransient<ISessieFacade, SessieFacade>();
            services.AddTransient<IFactuurFacade, FactuurFacade>();
            services.AddTransient<IRestaurantFacade, RestaurantFacade>();
            services.AddTransient<IReserveringenFacade, ReserveringenFacade>();
            services.AddTransient<IFavorietenFacade, FavorietenFacade>();
            services.AddTransient<IBestellingenFacade, BestellingenFacade>();
            services.AddTransient<IUserFacade, UserFacade>();
            services.AddTransient<ISessieRepository, SessieRepository>();
            services.AddTransient<IFactuurRepository, FactuurRepository>();
            services.AddTransient<IRestaurantRepository, RestaurantRepository>();
            services.AddTransient<IReserveringenRepository, ReserveringenRepository>();
            services.AddTransient<IFavorietenRepository, FavorietenRepository>();
            services.AddTransient<IBestellingenRepository, BestellingenRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DatabaseContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            DbInitializer.Initialize(context);
            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                         .AllowAnyMethod());
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
