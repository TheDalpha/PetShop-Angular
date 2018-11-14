using Oliver.PetShop.Core.DomainService;
using Oliver.PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oliver.PetShop.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        //public PetRepository(Pet)

        public Pet CreatePet(Pet pet)
        {
            throw new NotImplementedException();
        }

        public void DeletePet(int id)
        {
            throw new NotImplementedException();
        }

        public Pet ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> ReadPets()
        {
            throw new NotImplementedException();
        }
    }
}
