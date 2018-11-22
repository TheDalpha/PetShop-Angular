using Oliver.PetShop.Core.DomainService;
using Oliver.PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oliver.PetShop.Infrastructure.Data2.Repositories
{
    public class PetRepository : IPetRepository
    {
        readonly PetShopAppContext _ctx;

        public PetRepository(PetShopAppContext ctx)
        {
            _ctx = ctx;
        }

        public Pet CreatePet(Pet pet)
        {
            var pets = _ctx.Pets.Add(pet).Entity;
            _ctx.SaveChanges();
            return pets;
        }

        public Pet DeletePet(int id)
        {
            var removedPet = _ctx.Remove(new Pet { Id = id }).Entity;
            _ctx.SaveChanges();
            return removedPet;
        }

        public Pet ReadById(int id)
        {
            return _ctx.Pets.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Pet> ReadPets()
        {
            return _ctx.Pets;
        }

        public void UpdatePet(Pet pet)
        {
            _ctx.Update(pet);
            _ctx.SaveChanges();
        }
    }
}
