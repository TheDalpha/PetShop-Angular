using Oliver.PetShop.Core.ApplicationService;
using Oliver.PetShop.Core.ApplicationService.impl;
using Oliver.PetShop.Core.DomainService;
using Oliver.PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oliver.PetShop.ConsoleApp
{
    public class Printer
    {
        IPetService petService; 

        public Printer()
        {
            petService = new PetService();

            GetAllPets();

            
        }
        List<Pet> GetAllPets()
        {
            return petService.GetPets();
        }
    }
}
