using Oliver.PetShop.Core.DomainService;
using Oliver.PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oliver.PetShop.Core.ApplicationService.impl
{
    public class OwnerService : IOwnerService
    {

        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public Owner AddOwner(Owner owner)
        {
            return _ownerRepository.CreateOwner(owner);
        }

        public Owner DeleteOwner(int id)
        {
            return _ownerRepository.DeleteOwner(id);
        }

        public Owner GetInstance()
        {
            return new Owner();
        }

        public List<Owner> GetOwners()
        {
            var listOwners = _ownerRepository.ReadOwners().ToList();
            return listOwners;
        }

        public Owner ReadById(int id)
        {
            return _ownerRepository.ReadById(id);
        }

        public Owner UpdateOwner(int id, Owner owner)
        {
            var oldOwner = ReadById(id);
            oldOwner.Name = owner.Name;
            return oldOwner;
        }
    }
}
