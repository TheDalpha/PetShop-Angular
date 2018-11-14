using Microsoft.Extensions.DependencyInjection;
using Oliver.PetShop.Core.ApplicationService;
using Oliver.PetShop.Core.ApplicationService.impl;
using Oliver.PetShop.Core.DomainService;
using Oliver.PetShop.Infrastructure.Data2.Repositories;
using System;

namespace Oliver.PetShop.UI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //FakeDB.InitData();


            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var petService = serviceProvider.GetRequiredService<IPetService>();
            new Printer(petService);

            Console.ReadLine();
            /*////then build provider*/ 
            //var serviceProvider = serviceCollection.BuildServiceProvider();
            //var printer = serviceProvider.GetRequiredService<IPrinter>();
            //printer.StartUI();
        }
    }
    }
