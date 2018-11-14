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
        {C:\Users\ollie\Documents\GitHub\Webshop-Table\Group13.Webshop.Infrastructure.Data\Repositories\
            var pets = _ctx.Pets.Add(pet).Entity;
            _ctx.SaveChanges();
            return pets;
        }

        public void DeletePet(int id)
        {
            throw new NotImplementedException();
        }

        public Pet ReadById(int id)
        {
            return _ctx.Pets.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Pet> ReadPets()
        {
            return _ctx.Pets;
        }
    }
}
