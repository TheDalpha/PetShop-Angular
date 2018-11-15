using Oliver.PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oliver.PetShop.Core
{
    public class Owner
    {
        public Owner()
        {
        }

        public Owner(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public List<Pet> AllPets { get; set; }
    }
}
