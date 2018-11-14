using Oliver.PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oliver.PetShop.Core.ApplicationService
{
    public interface IPetService
    {
        List<Pet> GetPets();

        void DeletePet(int id);

        Pet AddPet(Pet pet);

        Pet GetInstance();

        Pet ReadById(int id);

        List<Pet> Get5CheapestPets();

        List<Pet> Search(string type);

        List<Pet> SortByPrice();

        Pet UpdatePet(int id, Pet pet);
    }
}
