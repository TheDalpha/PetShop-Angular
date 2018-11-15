using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Oliver.PetShop.Core;
using Oliver.PetShop.Core.ApplicationService;
using Oliver.PetShop.Core.ApplicationService.impl;
using Oliver.PetShop.Core.DomainService;
using Oliver.PetShop.Core.Entity;
using Oliver.PetShop.Infrastructure.Data2;
using Oliver.PetShop.Infrastructure.Data2.Repositories;

namespace Oliver.PetShop.UI.PetRestAPI
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
            services.AddDbContext<PetShopAppContext>(opt => opt.UseInMemoryDatabase("PetShop9876"));
            
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();

            services.AddMvc().AddJsonOptions(option =>
            {
                option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetShopAppContext>();

                    var owner1 = ctx.Owners.Add(new Owner()
                    {
                        Id = 1,
                        Name = "Børge"
                    }).Entity;

                    var owner2 = ctx.Owners.Add(new Owner()
                    {
                        Id = 2,
                        Name = "Hans"
                    }).Entity;

                    var pet1 = ctx.Pets.Add(new Pet()
                    {
                        Id = 1,
                        Name = "Jens",
                        Type = "Hund",
                        Color = "Blå",
                        PreviousOwner = owner1,
                        Price = 456
                    }).Entity;

                    var pet2 = ctx.Pets.Add(new Pet()
                    {
                        Id = 2,
                        Name = "Ole",
                        Type = "Kat",
                        Color = "Rød",
                        PreviousOwner = owner2,
                        Price = 489
                    });                    
                    ctx.SaveChanges();
                }
            }
            else
            {
                app.UseHsts();
            }

            app.UseMvc();
        }
    }
}
