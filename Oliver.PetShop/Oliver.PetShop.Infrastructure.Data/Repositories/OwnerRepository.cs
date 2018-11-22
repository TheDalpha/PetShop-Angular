using Oliver.PetShop.Core;
using Oliver.PetShop.Core.DomainService;
using Oliver.PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oliver.PetShop.Infrastructure.Data2.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        readonly PetShopAppContext _ctx;

        public OwnerRepository(PetShopAppContext ctx)
        {
            _ctx = ctx;
        }

        public Owner CreateOwner(Owner owner)
        {
            var own = _ctx.Owners.Add(owner).Entity;
            _ctx.SaveChanges();
            return own;
        }

        public Owner DeleteOwner(int id)
        {
            var removedOwner = _ctx.Remove(new Owner { Id = id }).Entity;
            _ctx.SaveChanges();
            return removedOwner;
        }

        public Owner ReadById(int id)
        {
            return _ctx.Owners.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Owner> ReadOwners()
        {
            return _ctx.Owners;
        }
    }
}
