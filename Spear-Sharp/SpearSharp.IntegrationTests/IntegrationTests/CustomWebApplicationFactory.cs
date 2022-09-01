using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SpearSharp.Database;
using SpearSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpearSharp.IntegrationTests.IntegrationTests
{
    public class CustomWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<ApplicationDbContext>));

                services.Remove(descriptor);

                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<ApplicationDbContext>();

                    db.Database.EnsureCreated();
                    
                    try
                    {
                        db.Kingdoms.Add(new Models.Kingdom { Id = 1, KingdomName = "Horna Marikova", Army = new List<Troop>(), Buildings=new List<Building>(), Ruler=new Player(), CoordinateX=1, CoordinateY=1,GoldAmount=12,FoodAmount=32 }) ;
                        db.Troops.Add(new Troop { Id=1,KingdomId = 1 });
                        db.Buildings.Add(new Building { Id=1,KingdomId = 1 });
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                    }
                }
            });
        }
    }
}
