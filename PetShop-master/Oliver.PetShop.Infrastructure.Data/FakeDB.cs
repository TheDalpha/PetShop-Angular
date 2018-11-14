using Oliver.PetShop.Core;
using Oliver.PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oliver.PetShop.Infrastructure.Data
{
    public static class FakeDB
    {
        public static int PetId = 1;
        public static int OwnerId = 1;
        public static IEnumerable<Pet> Pets;
        public static readonly List<Owner> Owners;

            public static void InitData()
            {
                Pet pet1 = new Pet()
                {
                    Id = PetId++,
                    Name = "Fluffy",
                    Type = "Doggo",
                    Birthday = new DateTime(2016, 02, 06),
                    SoldDate = new DateTime(2018, 01, 01),
                    Color = "Green",
                    PreviousOwner = new Owner(1),
                    Price = 2016458.125
                };

                

                Pet pet2 = new Pet()
                {
                    Id = PetId++,
                    Name = "Bolle",
                    Type = "Pølle Hund",
                    Birthday = new DateTime(1996, 02, 16),
                    SoldDate = new DateTime(2016, 04, 21),
                    Color = "Purple",
                    PreviousOwner = new Owner(2),
                    Price = 1.54
                };

            Pets = new List<Pet> { pet1, pet2 };

            

            
        }
        
    }
}
