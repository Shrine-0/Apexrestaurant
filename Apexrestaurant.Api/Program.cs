// global using Microsoft.EntityFrameworkCore;
// global using Apexrestaurant.Repository; 
// global using Microsoft.AspNetCore.Hosting;
// global using Microsoft.Extensions.DependencyInjection;
// global using Apexrestaurant.Services;


// var builder = WebApplication.CreateBuilder(args);
// var services =  new ServiceCollection();
// //builder.Services.ServiceModule.Register(services);

// // Add services to the container.
// //builder.Services.Configure<>();
// builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
// builder.Services.AddDbContext<RestaurantContext>(options=>
// {
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
// });
// builder.Services.AddMvc();
// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();   
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// app.UseAuthorization();

// app.MapControllers();
// //app.UseMvc();
// app.Run();
using System;
using Microsoft.AspNetCore.Hosting;
using Apexrestaurant.Api;
namespace Apexrestaurant.Api
{
    public class Program
    {
         public static void Main(String[] args)
         {
             var host = new WebHostBuilder()
             .UseKestrel()
             .UseStartup<Startup>()
             .Build();
             host.Run();
         }

    //     public static void Main(string[] args)
    // {
    //     CreateHostBuilder(args).Build().Run();
    // }

    // public static IHostBuilder CreateHostBuilder(string[] args) =>
    //     Host.CreateDefaultBuilder(args)
    //         .ConfigureWebHostDefaults(webBuilder =>
    //         {
    //             webBuilder.UseStartup<Startup>();
    //         });
    }
}
