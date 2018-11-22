using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Oliver.PetShop.Core.ApplicationService;
using Oliver.PetShop.Core.ApplicationService.impl;
using Oliver.PetShop.Core.DomainService;
using Oliver.PetShop.Core.Entity;
using Oliver.PetShop.Infrastructure.Data.Repositories;
using Oliver.PetShop.Infrastructure.Data2;
using Oliver.PetShop.Infrastructure.Data2.Repositories;
using Oliver.PetShop.UI.PetRestAPI.Helpers;

namespace Oliver.PetShop.UI.PetRestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
            JwtSecurityKey.SetSecret("a secret that needs to be at least 16 characters long");
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    //ValidAudience = "TodoApiClient",
                    ValidateIssuer = false,
                    //ValidIssuer = "TodoApi",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = JwtSecurityKey.Key,
                    ValidateLifetime = true, //validate the expiration and not before values in the token
                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                };
            });

            services.AddCors();

            services.AddDbContext<PetShopAppContext>(opt => opt.UseInMemoryDatabase("PetShop9876"));

            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

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

                    string password = "1234";
                    byte[] passwordHashJoe, passwordSaltJoe, passwordHashOle, passwordSaltOle;
                    CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
                    CreatePasswordHash(password, out passwordHashOle, out passwordSaltOle);

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

                    List<User> users = new List<User>
                    {
                        new User
                        {
                            Id = 1,
                        Username = "UserJoe",
                        PasswordHash = passwordHashJoe,
                        PasswordSalt = passwordSaltJoe,
                        IsAdmin = false
                        },
                        new User
                        {
                            Id = 2,
                        Username = "UserOle",
                        PasswordHash = passwordHashOle,
                        PasswordSalt = passwordSaltOle,
                        IsAdmin = true
                        }
                    };

                    ctx.Users.AddRange(users);
                    ctx.SaveChanges();
                }
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            app.UseMvc();
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

      }
}
