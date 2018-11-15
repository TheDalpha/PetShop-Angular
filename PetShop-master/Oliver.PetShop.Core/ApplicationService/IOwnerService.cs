using System;
using System.Collections.Generic;
using System.Text;

namespace Oliver.PetShop.Core.ApplicationService
{
    public interface IOwnerService
    {
        List<Owner> GetOwners();

        Owner DeleteOwner(int id);

        Owner AddOwner(Owner owner);

        Owner GetInstance();

        Owner ReadById(int id);

        Owner UpdateOwner(int id, Owner owner);
    }
}
