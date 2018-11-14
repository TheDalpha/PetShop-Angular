using System;
using System.Collections.Generic;
using System.Text;

namespace Oliver.PetShop.Core.DomainService
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> ReadOwners();

        void DeleteOwner(int id);

        Owner CreateOwner(Owner owner);

        Owner ReadById(int id);
    }
}
