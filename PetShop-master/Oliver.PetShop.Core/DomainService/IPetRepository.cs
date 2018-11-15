using Oliver.PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oliver.PetShop.Core.DomainService
{
    public interface IPetRepository
    {
        IEnumerable<Pet> ReadPets();

        Pet DeletePet(int id);

        Pet CreatePet(Pet pet);

        Pet ReadById(int id);

        void UpdatePet(Pet pet);
    }
}
