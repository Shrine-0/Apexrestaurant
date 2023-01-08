using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apexrestaurant.Repository;
using Apexrestaurant.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Apexrestaurant.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services tothe container.
        public void ConfigureServices(IServiceCollection services)
        {
             services.AddMvc(options => options.EnableEndpointRouting = false);//method 1(disable addmvc completely) --- for "Endpoint Routing does not support 'IApplicationBuilder.UseMvc(...)'". error 
            RepositoryModule.Register(services,
                Configuration.GetConnectionString("DefaultConnection"),
                GetType().Assembly.FullName);
            ServiceModule.Register(services);
            services.AddMvc();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)//IHostingEnvironment is deprecated apparently so use IWebHostenvironment env 
        {  
            //Method 2 (continuing to use MVC ) fot the "Endpoint Routing does not support 'IApplicationBuilder.UseMvc(...)'". error
            // app.UseRouting();

            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapControllers();
            // });
            //Method 2 ---end 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}